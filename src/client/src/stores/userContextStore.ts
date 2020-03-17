import { action, computed, observable, runInAction } from "mobx";
import { AccountApi } from "../core/api/accountApi";
import { UserType } from "../typings/dataContracts";

class UserContextStore {
    @observable public isAuthenticated: boolean;
    @observable public userType?: UserType;
    @observable public id?: string;

    @computed
    public get isStudent(): boolean {
        return this.userType === UserType.Student;
    }

    @computed
    public get isInstructor(): boolean {
        return this.userType === UserType.Instructor;
    }

    constructor() {
        this.isAuthenticated = false;
    }

    @action
    public loadContext = async () => {
        const result = await AccountApi.getContext();

        runInAction(() => {
            Object.assign(this, result);
        });
    };
}

export const userContextStore = new UserContextStore();
