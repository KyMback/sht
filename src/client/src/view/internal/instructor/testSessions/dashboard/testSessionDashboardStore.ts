import { action, observable, runInAction } from "mobx";
import { TestSessionApi } from "../../../../../core/api/testSessionApi";
import moment from "moment";
import { TestSessionDto, TestSessionStateTransitionRequest } from "../../../../../typings/dataContracts";
import { HttpApi } from "../../../../../core/api/http/httpApi";

export class TestSessionDashboardStore {
    @observable public id: string;
    @observable public name: string;
    @observable public createdAt: moment.Moment;
    @observable public state: string;
    @observable public triggers: Array<string> = [];

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
        await TestSessionApi.stateTransition(
            TestSessionStateTransitionRequest.fromJS({
                testSessionId: this.id,
                trigger,
            }),
        );
        await this.loadData();
    };
}

async function loadData(id: string): Promise<{ testSession: TestSessionDto; triggers: Array<string> }> {
    const query = `
query q($id:Uuid!) {
  testSession:testSessionDetails(where:{ id:$id }) {
    id
    name
    studentsIds
    testVariants {
      name
      testVariantId
    }
  }
  
  triggers:testSessionTriggers(testSessionId:$id)
}
    `;
    return HttpApi.graphQl<{ testSession: TestSessionDto; triggers: Array<string> }>(query, { id });
}
