import { action, computed, observable } from "mobx";
import { AnswersAssessmentQuestionEditDto, QuestionType } from "../../../../../../typings/dataContracts";
import { SelectItem } from "../../../../../../components/controls/multiSelect/multiSelect";
import { TestSessionDetailsEditStore } from "../testSessionDetailsEditStore";

export interface AnswersAssessmentQuestionRequiredData {
    id: string;
    questionText: string;
    questions: Array<string>;
}

export class AnswersAssessmentQuestionStore {
    @observable public id?: string;
    @observable public questionText?: string;
    @observable public questions: Array<SelectItem<string>> = [];

    @computed public get variantsQuestions(): Array<SelectItem<string>> {
        return this.testSessionDetailsEditStore.testVariants.flatMap(variant =>
            variant.questions
                .filter(e => e.id && e.name && e.type === QuestionType.FreeText)
                .map(e => ({
                    value: e.id!,
                    text: `${variant.name} - ${e.name}`,
                })),
        );
    }

    @action public setQuestionText = (value?: string) => (this.questionText = value);
    @action public setQuestions = (value?: Array<SelectItem<string>>) => (this.questions = value || []);

    constructor(
        private testSessionDetailsEditStore: TestSessionDetailsEditStore,
        private removeItem: (data: AnswersAssessmentQuestionStore) => void,
    ) {}

    @action
    public remove = () => {
        this.removeItem(this);
    };

    @action
    public setData = (data: AnswersAssessmentQuestionRequiredData) => {
        this.id = data.id;
        this.questionText = data.questionText;
        this.questions = this.variantsQuestions.filter(e => data.questions.includes(e.value));
    };

    public getDto = (): AnswersAssessmentQuestionEditDto => {
        return AnswersAssessmentQuestionEditDto.fromJS({
            id: this.id,
            questionText: this.questionText,
            questions: this.questions.map(e => e.value),
        });
    };
}
