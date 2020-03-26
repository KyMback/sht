import { observable, runInAction } from "mobx";
import { StudentTestSessionDto } from "../../../../typings/dataContracts";
import { HttpApi } from "../../../../core/api/http/httpApi";
import { TableResult } from "../../../../core/api/tableResult";

export class StudentTestSessionsStore {
    @observable testSessions: Array<StudentTestSessionDto> = [];

    public loadData = async () => {
        const { testSessions } = await loadData(10, 1);

        runInAction(() => {
            this.testSessions = testSessions.items;
        });
    };
}

interface LoadedData {
    testSessions: TableResult<StudentTestSessionDto>;
}

const query = `
query q($pageSize: Int!, $pageNumber: Int!) {
  testSessions: studentTestSessions(
    pageSize: $pageSize
    pageNumber: $pageNumber
    order_by: { createdAt: DESC }
  ) {
    items {
        id
        state
        name
        testVariant
        createdAt
    }
    total
  }
}
`;

async function loadData(pageSize: number, pageNumber: number): Promise<LoadedData> {
    return HttpApi.graphQl<LoadedData>(query, { pageSize, pageNumber });
}
