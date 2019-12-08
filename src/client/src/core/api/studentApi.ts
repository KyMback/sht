import { HttpApi } from "./http/httpApi";
import { StudentGroupedGroupDto } from "../../typings/dataContracts";

const endPoint = "/api/student";

export class StudentApi {
    public static getGroups = async (): Promise<Array<StudentGroupedGroupDto>> => {
        return HttpApi.get<Array<StudentGroupedGroupDto>>(`${endPoint}/groups`);
    }
}
