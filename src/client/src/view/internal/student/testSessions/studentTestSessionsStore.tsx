import { observable, runInAction } from "mobx";
import {
    SearchResultBaseFilter,
    StudentTestSessionListItemDto,
} from "../../../../typings/dataContracts";
import { StudentTestSessionApi } from "../../../../core/api/studentTestSessionApi";

export class StudentTestSessionsStore {
    @observable testSessions: Array<StudentTestSessionListItemDto> = [];

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
