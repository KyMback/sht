import { action, observable, runInAction } from "mobx";
import { TestSessionApi } from "../../../../core/api/testSessionApi";
import moment from "moment";
import { TestSessionStateTransitionRequest } from "../../../../typings/dataContracts";

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
        const result = await TestSessionApi.get(this.id);
        await this.loadAvailableActions();

        runInAction(() => {
            Object.assign(this, result);
        });
    };

    @action
    public loadAvailableActions = async () => {
        const result = await TestSessionApi.getAvailableTriggers(this.id);
        runInAction(() => {
            this.triggers = result;
        });
    };

    @action
    public stateTransition = async (trigger: string) => {
        await TestSessionApi.stateTransition(TestSessionStateTransitionRequest.fromJS({
            testSessionId: this.id,
            trigger,
        }));
        await this.loadData();
    };
}
