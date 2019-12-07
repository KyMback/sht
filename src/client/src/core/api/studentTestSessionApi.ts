import { HttpApi } from "./http/httpApi";
import { SearchResultBaseFilter, StudentTestSessionDto } from "../../typings/dataContracts";
import { TableResult } from "./tableResult";

const endPoint = "/api/student-test-session";

export class StudentTestSessionApi {
    public static getList = async (filter: SearchResultBaseFilter): Promise<TableResult<StudentTestSessionDto>> => {
        return HttpApi.get<TableResult<StudentTestSessionDto>>(`${endPoint}/list`, filter.toJSON());
    }
}
