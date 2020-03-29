import { AnswerStudentQuestionDto } from "../../typings/dataContracts";
import { HttpApi } from "./http/httpApi";

const endPoint = "/api/student-question";

export class StudentQuestionApi {
    public static answer = async (data: AnswerStudentQuestionDto) => {
        return HttpApi.put(`${endPoint}/answer`, data);
    };
}
