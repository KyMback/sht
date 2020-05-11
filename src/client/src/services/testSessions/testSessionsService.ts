import { CreatedEntityResponse, TestSessionModificationData } from "../../typings/dataContracts";
import { HttpApi } from "../../core/api/http/httpApi";

const mutations = {
    create: `
mutation($data: TestSessionModificationDataInput!) {
  createTestSession(data: $data) {
    id
  }
}
`,
    update: `
mutation($data: TestSessionModificationDataInput!, $testSessionId: ID!) {
  updateTestSession(data: $data, testSessionId: $testSessionId)
}
`,
    stateTransition: `
mutation($trigger: String!, $testSessionId: Uuid!) {
  testSessionStateTransition(trigger: $trigger, testSessionId: $testSessionId)
}
`,
};

export class TestSessionsService {
    public static create = async (data: TestSessionModificationData): Promise<CreatedEntityResponse> => {
        const { createTestSession } = await HttpApi.graphQl<{ createTestSession: CreatedEntityResponse }>(
            mutations.create,
            { data },
        );
        return createTestSession;
    };

    public static update = async (data: TestSessionModificationData, testSessionId: string) => {
        return HttpApi.graphQl(mutations.update, { data, testSessionId });
    };

    public static stateTransition = async (testSessionId: string, trigger: string) => {
        return HttpApi.graphQl(mutations.stateTransition, { testSessionId, trigger });
    };
}
