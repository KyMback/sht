import { AsyncInitializable } from "../../../../../../typings/customTypings";
import { computed, observable } from "mobx";
import { routingStore } from "../../../../../../stores/routingStore";

export class QuestionViewStore implements AsyncInitializable {
    @observable public id: string = "";

    @computed
    public get canEdt(): boolean {
        return true;
    }

    constructor(id: string) {
        this.id = id;
    }

    public init = async () => {
        await this.loadData();
    };

    public cancel = () => {
        routingStore.goto("/questions");
    };

    public edit = () => {
        routingStore.goto(`/questions/${this.id}/edit`);
    };

    private loadData = async () => {
        // runInAction(() => {
        // })
    };
}
