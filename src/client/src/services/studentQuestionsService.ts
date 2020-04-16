import { AnswerStudentQuestionDto } from "../typings/dataContracts";
import { HttpApi } from "../core/api/http/httpApi";

const mutations = {
    answer: `
mutation($data: AnswerStudentQuestionDtoInput!) {
    answerStudentQuestion(data: $data)
}
    `,
};

export class StudentQuestionsService {
    public static answer = async (data: AnswerStudentQuestionDto) => {
        return HttpApi.graphQl(mutations.answer, { data });
    };
}
