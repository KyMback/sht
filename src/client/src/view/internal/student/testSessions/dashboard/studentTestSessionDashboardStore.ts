import { computed, observable, runInAction } from "mobx";
import { StudentTestSessionsStateTransitionsService } from "../../../../../services/studentTestSessions/studentTestSessionsStateTransitionsService";
import { StartStudentTestConfirmationStore } from "../../../../../services/studentTestSessions/confirmations/startStudentTestConfirmationStore";
import { HttpApi } from "../../../../../core/api/http/httpApi";
import { StudentTestSessionState } from "../../../../../typings/studentTestSessionState";
import { StudentTestSessionTriggers } from "../../../../../typings/studentTestSessionTriggers";
import { StudentTestSessionsConfirmationsService } from "../../../../../services/studentTestSessions/studentTestSessionsConfirmationsService";
import { StudentTestSessionDataKey } from "../../../../../typings/studentTestSessionDataKey";
import { StudentTestSessionStateType } from "../studentTestSessionUtils";

export class StudentTestSessionDashboardStore {
    @observable public id: string;
    @observable public name: string = "";
    @observable public state: StudentTestSessionStateType = "Pending";
    @observable public testVariant?: string;
    @observable public stateTransitions: Array<string> = [];
    @observable public startStudentTestModalStore?: StartStudentTestConfirmationStore;

    @computed
    public get isQuestionsAvailable(): boolean {
        return this.state === StudentTestSessionState.Started;
    }

    constructor(id: string) {
        this.id = id;
    }

    public loadData = async () => {
        const { details, triggers } = await loadData(this.id);

        runInAction(() => {
            Object.assign(this, details);
            this.stateTransitions = triggers;
        });
    };

    public stateTransition = async (trigger: string) => {
        switch (trigger) {
            case StudentTestSessionTriggers.StartTest: {
                const variant = await StudentTestSessionsConfirmationsService.openChooseVariantConfirmation(this.id);
                if (variant) {
                    const data = {
                        [StudentTestSessionDataKey.TestVariant]: variant,
                    };
                    await this.stateTransitionInternal(trigger, data);
                }
                break;
            }
            default:
                await this.stateTransitionInternal(trigger);
        }
    };

    private stateTransitionInternal = async (trigger: string, data?: any) => {
        await StudentTestSessionsStateTransitionsService.stateTransition(this.id, trigger, data);
        await this.loadData();
    };
}

interface LoadedData {
    details: {
        id: string;
        name: string;
        state: string;
        testVariant: string;
    };
    triggers: Array<string>;
}

const query = `
query q($id: Uuid!) {  
  details: studentTestSession(where: {id: $id}) {
    id
    name
    state
    testVariant
  }
  
  triggers: studentTestSessionTriggers(testSessionId: $id)
}
`;

async function loadData(id: string): Promise<LoadedData> {
    return HttpApi.graphQl<LoadedData>(query, { id });
}
