import { HttpApi } from "./http/httpApi";
import { SignInDataDto, SignInResponse, SignUpStudentDataDto, UserContextDto } from "../../typings/dataContracts";
import * as queryString from "querystring";

const endpoint = "/api/account";

export class AccountApi {
    public static getContext = async (): Promise<UserContextDto> => {
        const query = `
        {
          userContext {
            id
            isAuthenticated
            userType
          }
        }
        `;
        const result = await HttpApi.graphQl<{ userContext: UserContextDto }>(query);
        return result.data.userContext;
    };

    public static confirmEmail = async (email: string, token: string) => {
        return HttpApi.get(`${endpoint}/confirm-email?${queryString.stringify({ email, token })}`);
    };

    public static signIn = async (data: SignInDataDto): Promise<SignInResponse> => {
        return HttpApi.post<SignInResponse>(`${endpoint}/signIn`, data);
    };

    public static signUp = async (data: SignUpStudentDataDto) => {
        return HttpApi.post(`${endpoint}/student/signUp`, data);
    };

    public static sightOut = async () => {
        return HttpApi.get(`${endpoint}/signOut`);
    };
}
