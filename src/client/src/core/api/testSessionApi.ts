import {
    CreatedEntityResponse,
    CreateTestSessionDto,
    SearchResultBaseFilter, TestSessionDto,
    TestSessionListItemDto,
} from "../../typings/dataContracts";
import { HttpApi } from "./http/httpApi";
import * as queryString from "querystring";
import { SearchResult } from "./searchResult";

const endpoint = "/api/test-session";

export class TestSessionApi {
    public static create = async (data: CreateTestSessionDto): Promise<CreatedEntityResponse> => {
        return HttpApi.post<CreatedEntityResponse>(endpoint, data);
    };

    public static get = async (id: string): Promise<TestSessionDto> => {
        return HttpApi.get<TestSessionDto>(`${endpoint}/${id}`);
    };

    public static getListItems = async (filter: SearchResultBaseFilter): Promise<SearchResult<TestSessionListItemDto>> => {
        return HttpApi.get<SearchResult<TestSessionListItemDto>>(`${endpoint}/list?${queryString.stringify(filter.toJSON())}`);
    };
}

