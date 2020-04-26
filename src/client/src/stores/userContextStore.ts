import { action, computed, observable } from "mobx";
import { UserType } from "../typings/dataContracts";
import { localStore } from "./localStore";

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
    public setContext = (data: ContextData) => {
        Object.assign(this, data);
        localStore.setLanguage(data.culture);
    };
}

export const userContextStore = new UserContextStore();

interface ContextData {
    id?: string;
    userType?: UserType;
    isAuthenticated: boolean;
    culture?: string;
}
