import { HttpApi } from "./http/httpApi";
import { StudentTestSessionDto, StudentTestSessionStateTransitionRequest } from "../../typings/dataContracts";

const endPoint = "/api/student-test-session";

export class StudentTestSessionApi {
    public static getTestVariants = async (id: string): Promise<Array<string>> => {
        return HttpApi.get<Array<string>>(`${endPoint}/test-variants/${id}`);
    };

    public static stateTransition = async (
        data: StudentTestSessionStateTransitionRequest,
    ): Promise<StudentTestSessionDto> => {
        return HttpApi.put(`${endPoint}/state`, data);
    };
}
