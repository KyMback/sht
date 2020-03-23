import { action, computed, observable, runInAction } from "mobx";
import { UserContextDto, UserType } from "../typings/dataContracts";
import { HttpApi } from "../core/api/http/httpApi";

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
        const result = await loadContext();

        runInAction(() => {
            Object.assign(this, result);
        });
    };
}

export const userContextStore = new UserContextStore();

async function loadContext(): Promise<UserContextDto> {
    const query = `
        {
          userContext {
            id
            isAuthenticated
            userType
          }
        }
        `;
    const { userContext } = await HttpApi.graphQl<{ userContext: UserContextDto }>(query);
    return userContext;
}
