import { CreatedEntityResponse, TestSessionDetailsDto } from "../typings/dataContracts";
import { HttpApi } from "../core/api/http/httpApi";

const mutations = {
    create: `
mutation($data: TestSessionDetailsDtoInput!) {
  createTestSession(data: $data) {
    id
  }
}
`,
    update: `
mutation($data: TestSessionDetailsDtoInput!) {
  updateTestSession(data: $data)
}
`,
    stateTransition: `
mutation($trigger: String!, $testSessionId: Uuid!) {
  testSessionStateTransition(trigger: $trigger, testSessionId: $testSessionId)
}
`,
};

export class TestSessionsService {
    public static create = async (data: TestSessionDetailsDto): Promise<CreatedEntityResponse> => {
        const { createTestSession } = await HttpApi.graphQl<{ createTestSession: CreatedEntityResponse }>(
            mutations.create,
            { data },
        );
        return createTestSession;
    };

    public static update = async (data: TestSessionDetailsDto) => {
        return HttpApi.graphQl(mutations.update, { data });
    };

    public static stateTransition = async (testSessionId: string, trigger: string) => {
        return HttpApi.graphQl(mutations.stateTransition, { testSessionId, trigger });
    };
}
