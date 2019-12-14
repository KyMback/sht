import { observable, runInAction } from "mobx";
import { SearchResultBaseFilter, TestVariantListItemDto } from "../../../../../typings/dataContracts";
import { TestVariantApi } from "../../../../../core/api/testVariantApi";

export class TestVariantsListPageStore {
    @observable testVariants: Array<TestVariantListItemDto> = [];

    public loadData = async () => {
        const result = await TestVariantApi.getList(SearchResultBaseFilter.fromJS({
            pageNumber: 1,
            pageSize: 100,
        }));

        runInAction(() => {
            this.testVariants = result.items;
        });
    };
}
