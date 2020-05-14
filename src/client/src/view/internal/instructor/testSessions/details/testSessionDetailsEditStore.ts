import { TestSessionsService } from "../../../../../services/testSessions/testSessionsService";
import {
    QuestionType,
    StudentGroupedGroupDto,
    TestSessionModificationData,
} from "../../../../../typings/dataContracts";
import { routingStore } from "../../../../../stores/routingStore";
import { action, observable, runInAction } from "mobx";
import { SelectItem } from "../../../../../components/controls/multiSelect/multiSelect";
import { Dictionary } from "../../../../../typings/customTypings";
import { pull, intersection, isEmpty } from "lodash";
import { HttpApi } from "../../../../../core/api/http/httpApi";
import { notifications } from "../../../../../components/notifications/notifications";
import { TestSessionVariantStore } from "./variants/testSessionVariantStore";
import { AssessmentSectionStore } from "./assessment/assessmentSectionStore";

export class TestSessionDetailsEditStore {
    public assessmentStore = new AssessmentSectionStore(this);

    @observable public id?: string;
    @observable public name?: string;
    @observable public groupedGroups: Dictionary<Array<string>> = {};
    @observable public groups: Array<SelectItem<string>> = [];
    @observable public selectedGroups: Array<SelectItem<string>> = [];
    @observable public testVariants: Array<TestSessionVariantStore> = [];

    constructor(id?: string) {
        this.id = id;
    }

    @action setName = (value?: string) => (this.name = value);
    @action setSelectedGroups = (value?: Array<SelectItem<string>>) => {
        this.selectedGroups = value || [];
    };

    @action
    public addNewTestVariant = () => {
        this.testVariants.push(new TestSessionVariantStore(this.removeTestVariant));
    };

    @action
    public removeTestVariant = (v: TestSessionVariantStore) => {
        pull(this.testVariants, v);
    };

    public save = async () => {
        let id = this.id;
        if (this.id) {
            await TestSessionsService.update(this.getDto(), this.id!);
        } else {
            const result = await TestSessionsService.create(this.getDto());
            id = result.id;
        }
        notifications.successfullySaved();
        routingStore.goto(`/test-session/dashboard/${id}`);
    };

    public cancel = () => {
        if (this.id) {
            routingStore.goto(`/test-session/${this.id}`);
        } else {
            routingStore.goto(`/test-session`);
        }
    };

    public loadData = async () => {
        const { groups, testSession } = await loadData(this.id);

        runInAction(() => {
            this.groupedGroups = groups.reduce((dict, g) => {
                dict[g.groupName] = g.studentsIds;
                return dict;
            }, {} as Dictionary<Array<string>>);
            this.groups = groups.map(e => ({
                value: e.groupName,
                text: e.groupName,
            }));

            if (testSession) {
                this.setData(testSession);
            }
        });
    };

    @action
    private setData = (data: TestSessionData) => {
        this.name = data.name;
        const groups: Array<string> = [];
        Object.entries(this.groupedGroups).forEach(([key, values]) => {
            if (!isEmpty(intersection(values, data.studentsIds!))) {
                groups.push(key);
            }
        });
        this.selectedGroups = this.groups.filter(e => groups.includes(e.value));
        this.testVariants = data.testVariants.map(e => {
            const store = new TestSessionVariantStore(this.removeTestVariant);
            store.setData(e);
            return store;
        });
        this.assessmentStore.setData(data.assessment);
    };

    private getDto = (): TestSessionModificationData => {
        return TestSessionModificationData.fromJS({
            id: this.id,
            name: this.name,
            studentsIds: this.selectedGroups
                .map(g => g.value)
                .map(g => this.groupedGroups[g])
                .flat(),
            variants: this.testVariants.map(e => e.getDto()),
            assessment: this.assessmentStore.getDto(),
        });
    };
}

interface LoadedData {
    testSession?: TestSessionData;
    groups: Array<StudentGroupedGroupDto>;
}

interface TestSessionData {
    id: string;
    name: string;
    studentsIds: string[];
    testVariants: TestVariantData[];
    assessment: {
        id: string;
        assessmentQuestions: Array<{
            id: string;
            questionText: string;
            questions: Array<string>;
        }>;
    };
}

interface TestVariantData {
    id: string;
    name: string;
    isRandomOrder: boolean;
    questions: Array<{
        id: string;
        name: string;
        order?: number;
        type: QuestionType;
        sourceQuestionId: string;
        choiceQuestion: {
            id: string;
            questionText: string;
            options: Array<{
                id: string;
                isCorrect: boolean;
                text: string;
            }>;
        };
        freeTextQuestion: {
            id: string;
            questionText: string;
        };
    }>;
}

const testSessionDetailsQuery = `
  testSession(where: { id: $id }) {
    id
    name
    studentsIds
    testVariants {
      name
      id
      isRandomOrder
      questions {
        id
        name
        order
        type
        sourceQuestionId
        choiceQuestion {
          id
          questionText
          options {
            id
            isCorrect
            text
          }
        }
        freeTextQuestion {
          id
          questionText
        }
      }
    }
    assessment {
      id
      assessmentQuestions {
        id
        questionText
        questions
      }
    }
  }
`;

async function loadData(id?: string): Promise<LoadedData> {
    const query = `
query q${id ? "($id:Uuid!)" : ""} {
${id ? testSessionDetailsQuery : ""}

  groups:studentsGroups {
    groupName
    studentsIds
  }
}
    `;
    return HttpApi.graphQl<LoadedData>(query, { id });
}
