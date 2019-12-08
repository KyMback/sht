import { HttpApi } from "./http/httpApi";
import {
    SearchResultBaseFilter,
    StudentTestSessionDto,
    StudentTestSessionListItemDto, StudentTestSessionStateTransitionRequest,
} from "../../typings/dataContracts";
import { TableResult } from "./tableResult";

const endPoint = "/api/student-test-session";

export class StudentTestSessionApi {
    public static getList = async (filter: SearchResultBaseFilter): Promise<TableResult<StudentTestSessionListItemDto>> => {
        return HttpApi.get<TableResult<StudentTestSessionListItemDto>>(`${endPoint}/list`, filter.toJSON());
    };

    public static get = async (id: string): Promise<StudentTestSessionDto> => {
        return HttpApi.get<StudentTestSessionDto>(`${endPoint}/${id}`);
    };

    public static getTestVariants = async (id: string): Promise<Array<string>> => {
        return HttpApi.get<Array<string>>(`${endPoint}/test-variants/${id}`);
    };

    public static stateTransition = async (data: StudentTestSessionStateTransitionRequest): Promise<StudentTestSessionDto> => {
        return HttpApi.put(`${endPoint}/state`, data);
    };

    public static getStateTransitions = async (id: string): Promise<Array<string>> => {
        return HttpApi.get<Array<string>>(`${endPoint}/state/${id}`);
    };
}
