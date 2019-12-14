import { action, observable, runInAction } from "mobx";
import { BaseQuestionStore } from "../infrasturcture/baseQuestionStore";
import { StudentQuestionApi } from "../../../../../../core/api/studentQuestionApi";
import { AnswerStudentQuestionDto } from "../../../../../../typings/dataContracts";
import { apiErrors, isExpected } from "../../../../../../core/api/http/apiError";
import { notifications } from "../../../../../../components/notifications/notifications";
import { routingStore } from "../../../../../../stores/routingStore";

export class FreeTextQuestionStore extends BaseQuestionStore {
    @observable public question?: string;
    @observable public answer?: string;

    @action public setAnswer = (value?: string) => this.answer = value;

    public loadData = async () => {
        if (this.isDataLoaded) {
            return;
        }

        const question = await StudentQuestionApi.get(this.id);

        runInAction(() => {
            Object.assign(this, question);
            this.isDataLoaded = true;
            this.question = question.text;
        });
    };

    public submit = async () => {
        try {
            await StudentQuestionApi.answer(AnswerStudentQuestionDto.fromJS({
                answer: this.answer,
                questionId: this.id,
            }));
            notifications.successfullySaved();
        } catch (e) {
            if (isExpected(e, apiErrors.studentTestSessionEnded)) {
                notifications.errorCode(apiErrors.studentTestSessionEnded);
                routingStore.goto(`/test-session/${this.sessionId}`);
                return;
            }

            throw e;
        }
    };
}
