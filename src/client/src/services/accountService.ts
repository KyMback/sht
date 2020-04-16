import { HttpApi } from "../core/api/http/httpApi";
import { SignInDataDto, SignInResponse, SignUpStudentDataDto } from "../typings/dataContracts";

const mutations = {
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
};

export class AccountService {
    public static confirmEmail = async (email: string, token: string) => {
        return HttpApi.graphQl(mutations.confirmEmail, {
            data: { email, token },
        });
    };

    public static signIn = async (data: SignInDataDto): Promise<SignInResponse> => {
        const { signIn } = await HttpApi.graphQl<{ signIn: SignInResponse }>(mutations.signIn, { data });
        return signIn;
    };

    public static signUpStudent = async (data: SignUpStudentDataDto) => {
        return HttpApi.graphQl(mutations.signUpStudent, {
            data,
        });
    };

    public static sightOut = async () => {
        return HttpApi.graphQl(mutations.sightOut);
    };
}
