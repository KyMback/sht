import { action, observable, runInAction } from "mobx";
import { BaseQuestionStore } from "../infrasturcture/baseQuestionStore";
import { AnswerStudentQuestionDto, FreeTextQuestionAnswerDto } from "../../../../../../typings/dataContracts";
import { HttpApi } from "../../../../../../core/api/http/httpApi";

export class FreeTextQuestionStore extends BaseQuestionStore {
    @observable public question?: string;
    @observable public answer?: string;

    @action public setAnswer = (value?: string) => (this.answer = value);

    public init = async () => {
        if (this.isInitialized) {
            return;
        }

        const question = await loadData(this.id);

        runInAction(() => {
            this.isInitialized = true;
            this.answer = question.answer?.freeTextAnswer.answer;
            this.question = question.freeTextQuestion.questionText;
        });
    };

    protected getDto = (): AnswerStudentQuestionDto => {
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
