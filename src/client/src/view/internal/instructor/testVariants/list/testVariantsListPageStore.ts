import { observable, runInAction } from "mobx";
import { TableResult } from "../../../../../core/api/tableResult";
import { HttpApi } from "../../../../../core/api/http/httpApi";

interface TestVariant {
    id: string;
    name: string;
    createdByName: string;
}

export class TestVariantsListPageStore {
    @observable testVariants: Array<TestVariant> = [];

    public loadData = async () => {
        const { testVariants } = await loadData(1, 10);

        runInAction(() => {
            this.testVariants = testVariants.items;
        });
    };
}

interface LoadedData {
    testVariants: TableResult<TestVariant>;
}

const query = `
query q($pageNumber: Int!, $pageSize: Int!) {
  testVariants(pageNumber: $pageNumber, pageSize: $pageSize) {
    items {
      id
      name
      createdByName
    }
    total
  }
}
`;

async function loadData(pageNumber: number, pageSize: number): Promise<LoadedData> {
    return HttpApi.graphQl(query, { pageNumber, pageSize });
}
