import { action, observable, runInAction } from "mobx";
import { AccountApi } from "../core/api/accountApi";
import { UserType } from "../typings/dataContracts";

class ContextStore {
    @observable public isAuthenticated: boolean;
    @observable public userType?: UserType;
    @observable public id?: string;

    constructor() {
        this.isAuthenticated = false;
    }

    @action
    public loadContext = async () => {
        const result = await AccountApi.getContext();

        runInAction(() => {
            Object.assign(this, result);
        });
    }
}

export const contextStore = new ContextStore();
