import { observable, runInAction } from "mobx";
import { SearchResultBaseFilter, StudentTestSessionDto } from "../../../../typings/dataContracts";
import { StudentTestSessionApi } from "../../../../core/api/studentTestSessionApi";

export class StudentTestSessionsStore {
    @observable testSessions: Array<StudentTestSessionDto> = [];

    public loadData = async () => {
        const result = await StudentTestSessionApi.getList(SearchResultBaseFilter.fromJS({
            pageNumber: 1,
            pageSize: 10,
        }));

        runInAction(() => {
            this.testSessions = result.items;
        });
    };
}