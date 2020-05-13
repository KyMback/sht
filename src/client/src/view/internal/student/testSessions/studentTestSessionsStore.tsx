import { observable, runInAction } from "mobx";
import { HttpApi } from "../../../../core/api/http/httpApi";
import { TableResult } from "../../../../core/api/tableResult";

export class StudentTestSessionsStore {
    @observable testSessions: Array<StudentTestSessionData> = [];

    public loadData = async () => {
        const testSessions = await loadData(10, 1);

        runInAction(() => {
            this.testSessions = testSessions.items;
        });
    };
}

interface StudentTestSessionData {
    id: string;
    state: string;
    name: string;
    testVariant: string;
    createdAt: Date;
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

async function loadData(pageSize: number, pageNumber: number): Promise<TableResult<StudentTestSessionData>> {
    const { testSessions } = await HttpApi.graphQl<{ testSessions: TableResult<StudentTestSessionData> }>(query, {
        pageSize,
        pageNumber,
    });

    return testSessions;
}
