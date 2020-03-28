import { action, computed, observable, runInAction } from "mobx";
import { HttpApi } from "../../../../../core/api/http/httpApi";

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

        const { details } = await loadData(this.id!);

        runInAction(() => {
            this.name = details.name;
        });
    };

    // eslint-disable-next-line @typescript-eslint/no-empty-function
    public save = async () => {};
}

interface LoadedData {
    details: {
        name: string;
    };
}

const query = `
query q($id: Uuid!) {
  details: testVariant(where: { id: $id }) {
    name
  }
}
`;

async function loadData(id: string): Promise<LoadedData> {
    return HttpApi.graphQl<LoadedData>(query, { id });
}
