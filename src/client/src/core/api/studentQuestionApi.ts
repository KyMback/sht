import { StudentQuestionDto } from "../../typings/dataContracts";
import { HttpApi } from "./http/httpApi";

const endPoint = "/api/student-question";

export class StudentQuestionApi {
    public static get = async (id: string): Promise<StudentQuestionDto> => {
        return HttpApi.get<StudentQuestionDto>(`${endPoint}/${id}`);
    };
}
