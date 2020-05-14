import { action, observable } from "mobx";
import { TestSessionDetailsEditStore } from "../testSessionDetailsEditStore";
import { AssessmentEditDto } from "../../../../../../typings/dataContracts";
import {
    AnswersAssessmentQuestionRequiredData,
    AnswersAssessmentQuestionStore,
} from "./answersAssessmentQuestionStore";
import { pull } from "lodash";

export interface AssessmentRequiredData {
    id: string;
    assessmentQuestions: Array<AnswersAssessmentQuestionRequiredData>;
}

export class AssessmentSectionStore {
    @observable public id?: string;
    @observable public answersAssessmentQuestions: Array<AnswersAssessmentQuestionStore> = [];

    constructor(private mainStore: TestSessionDetailsEditStore) {}

    @action public addNewAssessmentQuestion = () => {
        this.answersAssessmentQuestions.push(
            new AnswersAssessmentQuestionStore(this.mainStore, this.removeAnswerAssessmentQuestion),
        );
    };

    @action private removeAnswerAssessmentQuestion = (toRemove: AnswersAssessmentQuestionStore) => {
        pull(this.answersAssessmentQuestions, toRemove);
    };

    @action
    public setData = (data: AssessmentRequiredData) => {
        this.id = data.id;
        this.answersAssessmentQuestions = data.assessmentQuestions.map(d => {
            const store = new AnswersAssessmentQuestionStore(this.mainStore, this.removeAnswerAssessmentQuestion);
            store.setData(d);
            return store;
        });
    };

    public getDto = (): AssessmentEditDto => {
        return AssessmentEditDto.fromJS({
            id: this.id,
            assessmentQuestions: this.answersAssessmentQuestions.map(e => e.getDto()),
        });
    };
}
