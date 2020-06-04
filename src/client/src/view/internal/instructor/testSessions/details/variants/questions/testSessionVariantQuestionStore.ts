import { action, observable, runInAction } from "mobx";
import { QuestionType, TestSessionVariantQuestionModificationData } from "../../../../../../../typings/dataContracts";
import { AsyncInitializable } from "../../../../../../../typings/customTypings";
import { HttpApi } from "../../../../../../../core/api/http/httpApi";
import { SelectItem } from "../../../../../../../components/controls/multiSelect/multiSelect";
import { localStore } from "../../../../../../../stores/localStore";
import { getEnumValue } from "../../../../../../../core/localization/local";
import { RefObject } from "react";
import { FormActions } from "../../../../../../../components/forms/form";
import { QuestionsActionsService } from "../../../../../../../services/questions/questionsActionsService";
import {
    TestSessionVariantFreeTextQuestionRequiredData,
    TestSessionVariantFreeTextQuestionStore,
} from "./testSessionVariantFreeTextQuestionStore";
import {
    TestSessionVariantChoiceQuestionRequiredData,
    TestSessionVariantChoiceQuestionStore,
} from "./testSessionVariantChoiceQuestionStore";
import { MouseEvent } from "react";
import { FileInfo } from "../../../../../../../components/controls/files/simpleFilesUpload";

export interface TestSessionVariantQuestionRequiredData {
    id: string;
    name: string;
    type: QuestionType;
    order?: number;
    sourceQuestionId: string;
    images: Array<FileInfo>;
    freeTextQuestion?: TestSessionVariantFreeTextQuestionRequiredData;
    choiceQuestion?: TestSessionVariantChoiceQuestionRequiredData;
}

export class TestSessionVariantQuestionStore implements AsyncInitializable {
    @observable public id?: string;
    @observable public name?: string;
    @observable public type?: QuestionType;
    @observable public order?: number;
    @observable public images: Array<FileInfo> = [];
    @observable public sourceQuestionId?: string;
    @observable public freeTextQuestion?: TestSessionVariantFreeTextQuestionStore;
    @observable public choiceQuestion?: TestSessionVariantChoiceQuestionStore;

    public formRef?: RefObject<FormActions>;
    @observable public questions: Array<SelectItem<string>> = [];

    constructor(private removeQuestion: (toRemove: TestSessionVariantQuestionStore) => void) {}

    public setFormRef = (value: RefObject<FormActions>) => (this.formRef = value);

    @action
    public setSourceQuestionId = async (value: string) => {
        this.sourceQuestionId = value;
        await this.loadQuestion();
    };

    public remove = () => this.removeQuestion(this);

    public cancelEdit = (resolve: (data: boolean) => void) => {
        resolve(false);
    };

    public update = (e: MouseEvent, resolve: (data: boolean) => void) => {
        if (!this.formRef!.current!.isValid()) {
            e.preventDefault();
            return;
        }
        resolve(true);
    };

    public init = async () => {
        await this.loadLookups();
    };

    @action
    public setData = (data: TestSessionVariantQuestionRequiredData) => {
        this.id = data.id;
        this.name = data.name;
        this.type = data.type;
        this.order = data.order;
        this.sourceQuestionId = data.sourceQuestionId;
        this.images = data.images;
        switch (data.type) {
            case QuestionType.FreeText:
                this.freeTextQuestion = new TestSessionVariantFreeTextQuestionStore();
                this.choiceQuestion = undefined;
                this.freeTextQuestion.setData(data.freeTextQuestion!);
                break;
            case QuestionType.QuestionWithChoice:
                this.freeTextQuestion = undefined;
                this.choiceQuestion = new TestSessionVariantChoiceQuestionStore();
                this.choiceQuestion.setData(data.choiceQuestion!);
                break;
            default:
                throw new Error(`Not supported question type: ${data.type}`);
        }
        if (data.freeTextQuestion) {
            this.freeTextQuestion = new TestSessionVariantFreeTextQuestionStore();
            this.freeTextQuestion.setData(data.freeTextQuestion);
        }
        if (data.freeTextQuestion) {
            this.freeTextQuestion = new TestSessionVariantFreeTextQuestionStore();
            this.freeTextQuestion.setData(data.freeTextQuestion);
        }
    };

    public getDto = (): TestSessionVariantQuestionModificationData => {
        return TestSessionVariantQuestionModificationData.fromJS({
            ...this,
            images: this.images.map(e => e.id),
            freeTextQuestion: this.freeTextQuestion && this.freeTextQuestion.getDto(),
            choiceQuestion: this.choiceQuestion && this.choiceQuestion.getDto(),
        });
    };

    private loadLookups = async () => {
        const lookups = await loadLookups();

        runInAction(() => {
            this.questions = lookups.map(e => ({
                text: localStore.getLocalizedMessage("QuestionLookupItemTemplate", {
                    name: e.name,
                    type: getEnumValue(QuestionType, e.type),
                }),
                value: e.id,
            }));
        });
    };

    private loadQuestion = async () => {
        const details = await QuestionsActionsService.getDetails(this.sourceQuestionId!);

        runInAction(() => {
            this.name = details.name;
            this.type = details.type;
            this.images = details.images;
            switch (details.type) {
                case QuestionType.FreeText:
                    this.freeTextQuestion = new TestSessionVariantFreeTextQuestionStore();
                    this.choiceQuestion = undefined;
                    this.freeTextQuestion.setData({
                        questionText: details.freeTextQuestion!.question,
                    });
                    break;
                case QuestionType.QuestionWithChoice:
                    this.freeTextQuestion = undefined;
                    this.choiceQuestion = new TestSessionVariantChoiceQuestionStore();
                    this.choiceQuestion.setData({
                        options: details.choiceQuestion!.options.map(e => ({ ...e, id: undefined })),
                        questionText: details.choiceQuestion.questionText,
                    });
                    break;
                default:
                    throw new Error(`Not supported question type: ${details.type}`);
            }
        });
    };
}

interface QuestionLookupData {
    id: string;
    name: string;
    type: QuestionType;
}

const query = `
query q {
  questionsLookups: questions(pageNumber: 1, pageSize: 100) {
    items {
      name
      id
      type
    }
  }
}`;

async function loadLookups(): Promise<Array<QuestionLookupData>> {
    const { questionsLookups } = await HttpApi.graphQl<{ questionsLookups: { items: Array<QuestionLookupData> } }>(
        query,
    );
    return questionsLookups.items;
}
