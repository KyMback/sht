import { TestSessionApi } from "../../../../../core/api/testSessionApi";
import { Lookup, StudentGroupedGroupDto, TestSessionDetailsDto } from "../../../../../typings/dataContracts";
import { routingStore } from "../../../../../stores/routingStore";
import { action, observable, runInAction } from "mobx";
import { SelectItem } from "../../../../../components/controls/multiSelect/multiSelect";
import { Dictionary } from "../../../../../typings/customTypings";
import { pull, intersection, isEmpty } from "lodash";
import { HttpApi } from "../../../../../core/api/http/httpApi";

export class TestSessionDetailsEditStore {
    @observable id?: string;
    @observable name?: string;
    @observable groupedGroups: Dictionary<Array<string>> = {};
    @observable groups: Array<SelectItem<string>> = [];
    @observable selectedGroups: Array<string> = [];
    @observable testVariantsItems: Array<SelectItem<string>> = [];
    @observable testVariants: Array<TestVariant> = [];

    constructor(id?: string) {
        this.id = id;
    }

    @action setName = (value?: string) => (this.name = value);
    @action setSelectedGroups = (value?: Array<string>) => {
        this.selectedGroups = value || [];
    };
    @action setTestVariantsIds = (value: Array<TestVariant>) => (this.testVariants = value);

    @action
    public addNewTestVariant = () => {
        this.testVariants.push({});
    };

    @action
    public removeTestVariant = (v: TestVariant) => {
        this.testVariants = pull(this.testVariants, v);
    };

    public save = async () => {
        if (this.id) {
            await TestSessionApi.update(this.mapToDto(), this.id);
            this.cancel();
        } else {
            const result = await TestSessionApi.create(this.mapToDto());
            routingStore.goto(`/test-session/${result.id}`);
        }
    };

    public cancel = () => {
        if (this.id) {
            routingStore.goto(`/test-session/${this.id}`);
        } else {
            routingStore.goto(`/test-session`);
        }
    };

    public loadData = async () => {
        const { groups, testSession, variants } = await loadData(this.id);

        runInAction(() => {
            if (testSession) {
                this.name = testSession.name;
                const groups: Array<string> = [];
                Object.entries(this.groupedGroups).forEach(([key, values]) => {
                    if (!isEmpty(intersection(values, testSession.studentsIds))) {
                        groups.push(key);
                    }
                });
                this.selectedGroups = groups;
                this.testVariants = testSession.testVariants;
            }

            this.groupedGroups = groups.reduce((dict, g) => {
                dict[g.groupName] = g.studentsIds;
                return dict;
            }, {} as Dictionary<Array<string>>);
            this.groups = groups.map(e => ({
                value: e.groupName,
                text: e.groupName,
            }));
            this.testVariantsItems = [...variants];
        });
    };

    private mapToDto = (): TestSessionDetailsDto => {
        return TestSessionDetailsDto.fromJS({
            name: this.name,
            studentsIds: this.selectedGroups.map(g => this.groupedGroups[g]).flat(),
            testVariants: this.testVariants,
        });
    };
}

export interface TestVariant {
    testVariantId?: string;
    name?: string;
}

interface LoadedData {
    testSession?: TestSessionDetailsDto;
    variants: Array<Lookup>;
    groups: Array<StudentGroupedGroupDto>;
}

const testSessionDetailsQuery = `
  testSession:testSessionDetails(where:{ id:$id }) {
    id
    name
    studentsIds
    testVariants {
      name
      testVariantId
    }
  }
`;

async function loadData(id?: string): Promise<LoadedData> {
    const query = `
query q${id ? "($id:Uuid!)" : undefined} {
${id ? testSessionDetailsQuery : undefined}

  variants:testVariantLookups {
    text
    value
  }

  groups:studentsGroups {
    groupName
    studentsIds
  }
}
    `;
    return HttpApi.graphQl<LoadedData>(query, { id });
}
