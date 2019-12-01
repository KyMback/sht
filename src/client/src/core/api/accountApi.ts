import { HttpApi } from "./http/httpApi";
import { SignInDataDto, SignInResponse, SignUpDataDto, UserContextDto } from "../../typings/dataContracts";

const endpoint = "/api/account";

export class AccountApi {
    public static getContext = async (): Promise<UserContextDto> => {
        return HttpApi.get<UserContextDto>(`${endpoint}/context`);
    };

    public static signIn = async (data: SignInDataDto): Promise<SignInResponse> => {
        return HttpApi.post<SignInResponse>(`${endpoint}/signIn`, data);
    };

    public static signUp = async (data: SignUpDataDto) => {
        return HttpApi.post(`${endpoint}/signUp`, data);
    };

    public static sightOut = async () => {
        return HttpApi.get(`${endpoint}/signOut`);
    };
}
