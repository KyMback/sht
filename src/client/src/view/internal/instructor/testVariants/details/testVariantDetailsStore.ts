import { action, computed, observable, runInAction } from "mobx";
import { TestVariantApi } from "../../../../../core/api/testVariantApi";

export class TestVariantDetailsStore {
    @observable public id?: string;
    @observable public name?: string;

    @computed
    public get isNew(): boolean {
        return !this.id;
    }

    @action public setName = (value?: string) => (this.name = value);

    constructor(id?: string) {
        this.id = id;
    }

    public loadData = async () => {
        if (this.isNew) {
            return;
        }

        const result = await TestVariantApi.get(this.id!);

        runInAction(() => {
            this.name = result.name;
        });
    };

    // eslint-disable-next-line @typescript-eslint/no-empty-function
    public save = async () => {};
}
