import { HttpApi } from "../../core/api/http/httpApi";

const mutations = {
    stateTransition: `
mutation($studentTestSessionId: Uuid!, $trigger: String!, $serializedData: Any) {
    studentTestSessionStateTransition(studentTestSessionId: $studentTestSessionId, trigger: $trigger, serializedData: $serializedData)
}
`,
};

export class StudentTestSessionsStateTransitionsService {
    public static stateTransition = async (
        studentTestSessionId: string,
        trigger: string | undefined,
        serializedData: any,
    ) => {
        return HttpApi.graphQl(mutations.stateTransition, {
            studentTestSessionId,
            trigger,
            serializedData: JSON.stringify(serializedData),
        });
    };
}
