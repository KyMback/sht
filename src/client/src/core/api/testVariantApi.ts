import { Lookup, SearchResultBaseFilter, TestVariantListItemDto } from "../../typings/dataContracts";
import { HttpApi } from "./http/httpApi";
import { TableResult } from "./tableResult";

const endPoint = "/api/test-variant";

export class TestVariantApi {
    public static getLookups = async (): Promise<Array<Lookup>> => {
        return HttpApi.get<Array<Lookup>>(`${endPoint}/lookups`);
    };

    public static getList = async (filter: SearchResultBaseFilter): Promise<TableResult<TestVariantListItemDto>> => {
        return HttpApi.get<TableResult<TestVariantListItemDto>>(`${endPoint}/list`, filter.toJSON());
    };
}
