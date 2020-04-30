import { AsyncInitializable } from "../../../../../../typings/customTypings";
import { computed, observable } from "mobx";
import { routingStore } from "../../../../../../stores/routingStore";

export class QuestionEditStore implements AsyncInitializable {
    @observable public id?: string;

    @computed
    public get isNew(): boolean {
        return !this.id;
    }

    constructor(id?: string) {
        this.id = id;
    }

    public cancel = () => {
        if (this.isNew) {
            routingStore.goto("/questions");
        } else {
            routingStore.goto(`/questions/${this.id}`);
        }
    };

    public init = async () => {
        await this.loadData();
    };

    private loadData = async () => {
        // if(!this.isNew){
        // }
    };
}
