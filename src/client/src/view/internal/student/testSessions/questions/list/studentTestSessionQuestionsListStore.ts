import { observable, runInAction } from "mobx";
import { StudentTestQuestionListItemDto } from "../../../../../../typings/dataContracts";
import { StudentTestSessionApi } from "../../../../../../core/api/studentTestSessionApi";

export class StudentTestSessionQuestionsListStore {
    @observable sessionId: string;
    @observable questions: Array<StudentTestQuestionListItemDto> = [];

    constructor(sessionId: string) {
        this.sessionId = sessionId;
    }

    public loadData = async () => {
        const questions = await StudentTestSessionApi.getTestQuestions(this.sessionId);

        runInAction(() => {
            this.questions = questions;
        })
    };
}
