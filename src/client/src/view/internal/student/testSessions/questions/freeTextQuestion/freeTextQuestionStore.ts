import { action, observable, runInAction } from "mobx";
import { BaseQuestionStore } from "../infrasturcture/baseQuestionStore";
import { AnswerStudentQuestionDto } from "../../../../../../typings/dataContracts";
import { apiErrors, isExpected } from "../../../../../../core/api/http/apiError";
import { notifications } from "../../../../../../components/notifications/notifications";
import { routingStore } from "../../../../../../stores/routingStore";
import { HttpApi } from "../../../../../../core/api/http/httpApi";
import { StudentQuestionsService } from "../../../../../../services/studentQuestionsService";

export class FreeTextQuestionStore extends BaseQuestionStore {
    @observable public question?: string;
    @observable public answer?: string;

    @action public setAnswer = (value?: string) => (this.answer = value);

    public loadData = async () => {
        if (this.isDataLoaded) {
            return;
        }

        const { question } = await loadData(this.id);

        runInAction(() => {
            this.isDataLoaded = true;
            this.answer = question.answer;
            this.question = question.question;
        });
    };

    public submit = async () => {
        try {
            await StudentQuestionsService.answer(
                AnswerStudentQuestionDto.fromJS({
                    answer: this.answer,
                    questionId: this.id,
                }),
            );
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

interface LoadedData {
    question: {
        question: string;
        answer?: string;
    };
}

const query = `
query q($id: Uuid!) {
  question: studentTestQuestion(where:{id: $id}) {
    question: text
    answer
  }
}
`;

async function loadData(id: string): Promise<LoadedData> {
    return HttpApi.graphQl<LoadedData>(query, { id });
}
