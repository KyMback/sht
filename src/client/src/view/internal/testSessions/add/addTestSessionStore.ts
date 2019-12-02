import { TestSessionApi } from "../../../../core/api/testSessionApi";
import { CreateTestSessionDto } from "../../../../typings/dataContracts";
import { routingStore } from "../../../../stores/routingStore";
import { action, observable } from "mobx";

export class AddTestSessionStore {
    @observable name?: string;
    @observable studentsIds: Array<string> = [];
    @observable testVariantsIds: Array<string> = [];

    @action setName = (value?: string) => this.name = value;
    @action setStudentsIds = (value: Array<string>) => this.studentsIds = value;
    @action setTestVariantsIds = (value: Array<string>) => this.testVariantsIds = value;

    public submit = async () => {
        await TestSessionApi.create(CreateTestSessionDto.fromJS({
            name: this.name,
            studentsIds: this.studentsIds,
            testVariantsIds: this.testVariantsIds,
        }));
        routingStore.goto("/test-sessions");
    };
}
