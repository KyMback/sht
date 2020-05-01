import { AsyncInitializable } from "../../../../../../typings/customTypings";
import { action, computed, observable, runInAction } from "mobx";
import { routingStore } from "../../../../../../stores/routingStore";
import { QuestionEditDetailsDto, QuestionType } from "../../../../../../typings/dataContracts";
import { FreeTextQuestionEditSectionStore } from "./sections/freeText/freeTextQuestionEditSectionStore";
import { QuestionsActionsService } from "../../../../../../services/questions/questionsActionsService";
import { notifications } from "../../../../../../components/notifications/notifications";

export class QuestionEditStore implements AsyncInitializable {
    @observable public id?: string;
    @observable public name?: string;
    @observable public type?: QuestionType;

    @observable public freeTextStore?: FreeTextQuestionEditSectionStore;

    @computed
    public get isNew(): boolean {
        return !this.id;
    }

    @action
    public setName = (value?: string) => {
        this.name = value;
    };

    @action
    public setType = (value?: QuestionType) => {
        this.type = value;
        this.buildSpecialQuestionStoreByType(value!);
    };

    constructor(id?: string) {
        this.id = id;
    }

    public cancel = () => {
        if (this.isNew) {
            routingStore.goto("/questions");
        } else {
            routingStore.goto(`/questions/${this.id}`);
        }
    };

    public init = async () => {
        await this.loadData();
    };

    public save = async () => {
        if (this.isNew) {
            await this.create();
        } else {
            await this.update();
        }
    };

    private create = async () => {
        const result = await QuestionsActionsService.create(this.getDto());
        notifications.successfullySaved();
        routingStore.goto(`/questions/${result.id}`);
    };

    private update = async () => {
        await QuestionsActionsService.update(this.id!, this.getDto());
        notifications.successfullySaved();
        routingStore.goto(`/questions/${this.id}`);
    };

    private loadData = async () => {
        if (this.isNew) {
            return;
        }

        const data = await QuestionsActionsService.getDetails(this.id!);

        runInAction(() => {
            this.name = data.name;
            this.type = data.type;
            this.buildSpecialQuestionStoreByType(data.type);
            switch (data.type) {
                case QuestionType.FreeText:
                    this.freeTextStore!.setData(data.freeTextQuestion!);
            }
        });
    };

    private getDto = (): QuestionEditDetailsDto => {
        return QuestionEditDetailsDto.fromJS({
            type: this.type,
            name: this.name,
            freeTextQuestionData: this.freeTextStore && this.freeTextStore.getDto(),
        });
    };

    private buildSpecialQuestionStoreByType = (type: QuestionType) => {
        switch (type) {
            case QuestionType.FreeText:
                this.freeTextStore = new FreeTextQuestionEditSectionStore();
                return;
            default:
                throw new Error(`Not supported question type: ${type}`);
        }
    };
}
