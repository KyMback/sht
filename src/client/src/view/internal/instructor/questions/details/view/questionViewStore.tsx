import { AsyncInitializable } from "../../../../../../typings/customTypings";
import { computed, observable, runInAction } from "mobx";
import { routingStore } from "../../../../../../stores/routingStore";
import { QuestionsActionsService } from "../../../../../../services/questions/questionsActionsService";
import { QuestionType } from "../../../../../../typings/dataContracts";
import { userContextStore } from "../../../../../../stores/userContextStore";
import { FreeTextQuestionViewSectionStore } from "./sections/freeText/freeTextQuestionViewSectionStore";

export class QuestionViewStore implements AsyncInitializable {
    @observable public id: string = "";
    @observable public name: string = "";
    @observable public type?: QuestionType;
    @observable public createdById?: string;

    @observable public freeTextQuestionStore?: FreeTextQuestionViewSectionStore;

    @computed
    public get canEdt(): boolean {
        return this.createdById === userContextStore.id;
    }

    constructor(id: string) {
        this.id = id;
    }

    public init = async () => {
        await this.loadData();
    };

    public cancel = () => {
        routingStore.goto("/questions");
    };

    public edit = () => {
        routingStore.goto(`/questions/${this.id}/edit`);
    };

    private loadData = async () => {
        const data = await QuestionsActionsService.getExtendedDetails(this.id);

        runInAction(() => {
            this.name = data.name;
            this.type = data.type;
            this.createdById = data.createdById;

            switch (data.type) {
                case QuestionType.FreeText:
                    this.freeTextQuestionStore = new FreeTextQuestionViewSectionStore();
                    this.freeTextQuestionStore.setData(data.freeTextQuestion);
            }
        });
    };
}
