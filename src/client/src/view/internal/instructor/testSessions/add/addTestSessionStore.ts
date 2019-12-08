import { TestSessionApi } from "../../../../../core/api/testSessionApi";
import { CreateTestSessionDto } from "../../../../../typings/dataContracts";
import { routingStore } from "../../../../../stores/routingStore";
import { action, observable, runInAction } from "mobx";
import { SelectItem } from "../../../../../components/controls/multiSelect/multiSelect";
import { StudentApi } from "../../../../../core/api/studentApi";
import { TestVariantApi } from "../../../../../core/api/testVariantApi";
import { Dictionary } from "../../../../../typings/customTypings";

export class AddTestSessionStore {
    @observable name?: string;
    @observable groupedGroups: Dictionary<Array<string>> = {};
    @observable groups: Array<SelectItem<string>> = [];
    @observable selectedGroups: Array<string> = [];
    @observable testVariantsItems: Array<SelectItem<string>> = [];
    @observable testVariants: Array<TestVariant> = [];

    @action setName = (value?: string) => this.name = value;
    @action setSelectedGroups = (value?: Array<string>) => {
        this.selectedGroups = value || [];
    };
    @action setTestVariantsIds = (value: Array<TestVariant>) => this.testVariants = value;

    public submit = async () => {
        await TestSessionApi.create(CreateTestSessionDto.fromJS({
            name: this.name,
            studentsIds: this.selectedGroups.map(g => this.groupedGroups[g]).flat(),
            testVariants: this.testVariants,
        }));
        routingStore.goto("/test-sessions");
    };

    public loadData = async () => {
        await this.loadAdditionalInfo();
    };

    private loadAdditionalInfo = async () => {
        const groups = await StudentApi.getGroups();
        const variantLookups = await TestVariantApi.getLookups();

        runInAction(() => {
            this.groupedGroups = groups.reduce((dict, g) => {
                dict[g.groupName] = g.studentsIds;
                return dict;
            }, {} as Dictionary<Array<string>>);
            this.groups = groups.map(e => ({
                value: e.groupName,
                text: e.groupName,
            }));
            this.testVariantsItems = variantLookups;
        });
    };
}

export interface TestVariant {
    testVariantId: string;
    name: string;
}
