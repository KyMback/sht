import { computed, observable, runInAction } from "mobx";
import { StudentTestSessionsService } from "../../../../../services/studentTestSessionsService";
import { StudentTestSessionDto } from "../../../../../typings/dataContracts";
import { studentTestSessionStateTriggers } from "./stateTransition/studentTestSessionStateTriggers";
import { StartStudentTestModalStore } from "./stateTransition/startTest/startStudentTestModalStore";
import { studentTestSessionStates } from "./stateTransition/studentTestSessionStates";
import { HttpApi } from "../../../../../core/api/http/httpApi";

export class StudentTestSessionDashboardStore {
    @observable public id: string;
    @observable public name: string = "";
    @observable public state: string = "";
    @observable public testVariant?: string;
    @observable public stateTransitions: Array<string> = [];
    @observable public startStudentTestModalStore?: StartStudentTestModalStore;

    @computed
    public get isQuestionsAvailable(): boolean {
        return this.state === studentTestSessionStates.started;
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
        if (trigger === studentTestSessionStateTriggers.startTest) {
            this.startStudentTestModalStore = new StartStudentTestModalStore(
                this.id,
                this.stateTransitionInternal,
                () => (this.startStudentTestModalStore = undefined),
            );
            this.startStudentTestModalStore.open();
        } else {
            await this.stateTransitionInternal(trigger);
        }
    };

    private stateTransitionInternal = async (trigger: string, data?: any) => {
        await StudentTestSessionsService.stateTransition(this.id, trigger, data);
        await this.loadData();
    };
}

interface LoadedData {
    details: StudentTestSessionDto;
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
