import { HttpApi } from "./httpApi";
import { UserContextDto } from "../../typings/dataContracts";

const endpoint = "api/account";

export class AccountApi {
    public static getContext = (): Promise<UserContextDto> => {
        return HttpApi.get<UserContextDto>(`${endpoint}/context`);
    }
}
