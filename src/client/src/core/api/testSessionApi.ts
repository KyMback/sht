import {
    CreatedEntityResponse,
    SearchResultBaseFilter, TestSessionDetailsDto, TestSessionDto,
    TestSessionListItemDto, TestSessionStateTransitionRequest,
} from "../../typings/dataContracts";
import { HttpApi } from "./http/httpApi";
import { TableResult } from "./tableResult";

const endpoint = "/api/test-session";

export class TestSessionApi {
    public static create = async (data: TestSessionDetailsDto): Promise<CreatedEntityResponse> => {
        return HttpApi.post<CreatedEntityResponse>(endpoint, data);
    };

    public static update = async (data: TestSessionDetailsDto, id: string) => {
        return HttpApi.put(`${endpoint}/${id}`, data);
    };

    public static get = async (id: string): Promise<TestSessionDto> => {
        return HttpApi.get<TestSessionDto>(`${endpoint}/${id}`);
    };

    public static getDetails = async (id: string): Promise<TestSessionDetailsDto> => {
        return HttpApi.get<TestSessionDetailsDto>(`${endpoint}/details/${id}`);
    };

    public static getListItems = async (filter: SearchResultBaseFilter): Promise<TableResult<TestSessionListItemDto>> => {
        return HttpApi.get<TableResult<TestSessionListItemDto>>(`${endpoint}/list`, filter.toJSON());
    };

    public static getAvailableTriggers = async (id: string): Promise<Array<string>> => {
        return HttpApi.get<Array<string>>(`${endpoint}/state/${id}`);
    };

    public static stateTransition = async (data: TestSessionStateTransitionRequest) => {
        return HttpApi.put(`${endpoint}/state`, data);
    };
}

