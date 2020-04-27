import { action, computed, observable, runInAction } from "mobx";
import { TestSessionsService } from "../../../../../services/testSessionsService";
import moment from "moment";
import { HttpApi } from "../../../../../core/api/http/httpApi";

export class TestSessionDashboardStore {
    @observable public id: string;
    @observable public name: string;
    @observable public createdAt: moment.Moment;
    @observable public state: string;
    @observable public triggers: Array<string> = [];

    @computed
    public get canEdit(): boolean {
        return this.state === "Pending";
    }

    constructor(id: string) {
        this.id = id;
        this.name = "";
        this.state = "";
        this.createdAt = moment();
    }

    @action
    public loadData = async () => {
        const data = await loadData(this.id);

        runInAction(() => {
            Object.assign(this, data.testSession);
            this.triggers = data.triggers;
        });
    };

    @action
    public stateTransition = async (trigger: string) => {
        await TestSessionsService.stateTransition(this.id, trigger);
        await this.loadData();
    };
}

interface LoadedData {
    testSession: {
        id: string;
        name: string;
        studentsIds: Array<string>;
        state: string;
        testVariants: Array<{
            name: string;
            testVariantId: string;
        }>;
    };
    triggers: Array<string>;
}

async function loadData(id: string): Promise<LoadedData> {
    const query = `
query q($id:Uuid!) {
  testSession:testSessionDetails(where:{ id:$id }) {
    id
    name
    studentsIds
    state
    testVariants {
      name
      testVariantId
    }
  }
  
  triggers:testSessionTriggers(testSessionId:$id)
}
    `;
    return HttpApi.graphQl<LoadedData>(query, { id });
}
