import { observable, runInAction } from "mobx";
import { StudentTestSessionApi } from "../../../../../core/api/studentTestSessionApi";
import { StudentTestSessionStateTransitionRequest } from "../../../../../typings/dataContracts";
import { studentTestSessionStateTriggers } from "./stateTransition/studentTestSessionStateTriggers";
import { StartStudentTestModalStore } from "./stateTransition/startTest/startStudentTestModalStore";

export class StudentTestSessionDashboardStore {
    @observable public id: string;
    @observable public name: string = "";
    @observable public state: string = "";
    @observable public variant?: string;
    @observable public stateTransitions: Array<string> = [];
    @observable public startStudentTestModalStore?: StartStudentTestModalStore;

    constructor(id: string) {
        this.id = id;
    }

    public loadData = async () => {
        const data = await StudentTestSessionApi.get(this.id);
        const triggers = await StudentTestSessionApi.getStateTransitions(this.id);

        runInAction(() => {
            Object.assign(this, data);
            this.stateTransitions = triggers;
        });
    };

    public stateTransition = async (trigger: string) => {
        if (trigger === studentTestSessionStateTriggers.startTest) {
            this.startStudentTestModalStore = new StartStudentTestModalStore(
                this.id,
                this.stateTransitionInternal,
                () => this.startStudentTestModalStore = undefined);
            this.startStudentTestModalStore.open();
        } else {
            await this.stateTransitionInternal(trigger);
        }
    };

    private stateTransitionInternal = async (trigger: string, data?: any) => {
        await StudentTestSessionApi.stateTransition(StudentTestSessionStateTransitionRequest.fromJS({
            studentTestSessionId: this.id,
            trigger: trigger,
            serializedData: data,
        }));

        await this.loadData();
    };
}

