import { action, observable, runInAction } from "mobx";
import { BaseQuestionStore } from "../infrasturcture/baseQuestionStore";
import { AnswerStudentQuestionDto, FreeTextQuestionAnswerDto } from "../../../../../../typings/dataContracts";
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

        const question = await loadData(this.id);

        runInAction(() => {
            this.isDataLoaded = true;
            this.answer = question.answer?.freeTextAnswer.answer;
            this.question = question.freeTextQuestion.questionText;
        });
    };

    public submit = async () => {
        try {
            await StudentQuestionsService.answer(this.getDto());
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

    private getDto = (): AnswerStudentQuestionDto => {
        return AnswerStudentQuestionDto.fromJS({
            questionId: this.id,
            freeTextAnswer: FreeTextQuestionAnswerDto.fromJS({
                answer: this.answer,
            }),
        });
    };
}

interface QuestionData {
    freeTextQuestion: {
        questionText: string;
    };
    answer?: {
        freeTextAnswer: {
            answer?: string;
        };
    };
}

const query = `
query q($id: Uuid!) {
  question: studentTestQuestion(where: { id: $id }) {
    freeTextQuestion {
      questionText
    }
    answer {
      freeTextAnswer {
        answer
      }
    }
  }
}
`;

async function loadData(id: string): Promise<QuestionData> {
    const { question } = await HttpApi.graphQl<{ question: QuestionData }>(query, { id });
    return question;
}
