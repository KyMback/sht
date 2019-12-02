import { SearchResultBaseFilter, TestSessionListItemDto } from "../../typings/dataContracts";
import { HttpApi } from "./http/httpApi";
import * as queryString from "querystring";
import { SearchResult } from "./searchResult";

const endpoint = "/api/test-session";

export class TestSessionApi {
    public static getListItems = async (filter: SearchResultBaseFilter): Promise<SearchResult<TestSessionListItemDto>> => {
        return HttpApi.get<SearchResult<TestSessionListItemDto>>(`${endpoint}/list?${queryString.stringify(filter.toJSON())}`);
    };
}

