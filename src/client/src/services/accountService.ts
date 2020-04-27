import { HttpApi } from "../core/api/http/httpApi";
import { SignInDataDto, SignInResponse, SignUpStudentDataDto, UserContextDto } from "../typings/dataContracts";
import { userContextStore } from "../stores/userContextStore";

const queries = {
    confirmEmail: `
mutation($data: ConfirmEmailDataDtoInput!) {
  confirmEmail(data: $data)
}
    `,
    signIn: `
mutation($data: SignInDataDtoInput!) {
  signIn(data: $data) {
    succeeded
  }
}
`,
    signUpStudent: `
mutation($data: SignUpStudentDataDtoInput!) {
  signUpStudent(data: $data)
}
`,
    sightOut: `
mutation {
  signOut
}
`,
    loadUserContext: `
{
  userContext {
    id
    isAuthenticated
    userType
    culture
  }
}`,
    setCulture: `
mutation($culture: String!) {
  setCulture(culture: $culture)
}`,
};

export class AccountService {
    public static confirmEmail = async (email: string, token: string) => {
        return HttpApi.graphQl(queries.confirmEmail, {
            data: { email, token },
        });
    };

    public static signIn = async (data: SignInDataDto): Promise<SignInResponse> => {
        const { signIn } = await HttpApi.graphQl<{ signIn: SignInResponse }>(queries.signIn, { data });
        return signIn;
    };

    public static signUpStudent = async (data: SignUpStudentDataDto) => {
        return HttpApi.graphQl(queries.signUpStudent, {
            data,
        });
    };

    public static sightOut = async () => {
        return HttpApi.graphQl(queries.sightOut);
    };

    public static setCulture = async (culture: string) => {
        return HttpApi.graphQl(queries.setCulture, { culture });
    };

    public static async updateUserContext() {
        const { userContext } = await HttpApi.graphQl<{ userContext: UserContextDto }>(queries.loadUserContext);
        userContextStore.setContext(userContext);
    }
}
