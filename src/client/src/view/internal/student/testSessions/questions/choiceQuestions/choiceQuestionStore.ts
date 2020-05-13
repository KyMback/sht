import { BaseQuestionStore } from "../infrasturcture/baseQuestionStore";
import { observable, runInAction } from "mobx";
import { HttpApi } from "../../../../../../core/api/http/httpApi";
import { AnswerStudentQuestionDto, ChoiceQuestionAnswerDto } from "../../../../../../typings/dataContracts";
import { isEmpty } from "lodash";

export class ChoiceQuestionStore extends BaseQuestionStore {
    @observable public question?: string;
    @observable public options: Array<SelectOption> = [];

    public init = async () => {
        if (this.isInitialized) {
            return;
        }

        const question = await loadData(this.id);

        runInAction(() => {
            this.question = question.choiceQuestion.questionText;
            this.options = question.choiceQuestion.options.map(e => ({
                ...e,
                isChecked: false,
            }));

            if (question.answer && !isEmpty(question.answer.choiceQuestionAnswers)) {
                question.answer.choiceQuestionAnswers.forEach(a => {
                    const option = this.options.find(q => q.id === a.optionId);
                    if (option) {
                        option.isChecked = true;
                    }
                });
            }
        });
    };

    protected getDto = (): AnswerStudentQuestionDto => {
        return AnswerStudentQuestionDto.fromJS({
            questionId: this.id,
            choiceQuestionAnswer: ChoiceQuestionAnswerDto.fromJS({
                answers: this.options.filter(e => e.isChecked).map(e => e.id),
            }),
        });
    };
}

interface SelectOption {
    id: string;
    text: string;
    isChecked: boolean;
}

interface QuestionData {
    choiceQuestion: {
        questionText: string;
        options: Array<{
            id: string;
            text: string;
        }>;
    };
    answer: {
        choiceQuestionAnswers: Array<{
            optionId: string;
        }>;
    };
}

const query = `
query q($id: Uuid!) {
  question: studentTestQuestion(where: { id: $id }) {
    choiceQuestion {
      questionText
      options {
        id
        text
      }
    }
    answer {
       choiceQuestionAnswers {
        optionId
      }
    }
  }
}
`;

async function loadData(id: string): Promise<QuestionData> {
    const { question } = await HttpApi.graphQl<{ question: QuestionData }>(query, { id });
    return question;
}
