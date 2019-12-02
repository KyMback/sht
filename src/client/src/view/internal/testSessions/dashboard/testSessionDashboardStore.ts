import { action, observable, runInAction } from "mobx";
import { TestSessionApi } from "../../../../core/api/testSessionApi";
import moment from "moment";

export class TestSessionDashboardStore {
    @observable public id: string;
    @observable public name: string;
    @observable public createdAt: moment.Moment;
    @observable public state: string;

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
    };
}
