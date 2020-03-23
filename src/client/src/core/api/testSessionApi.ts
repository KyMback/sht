import {
    CreatedEntityResponse,
    TestSessionDetailsDto,
    TestSessionDto,
    TestSessionStateTransitionRequest,
} from "../../typings/dataContracts";
import { HttpApi } from "./http/httpApi";

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

    public static stateTransition = async (data: TestSessionStateTransitionRequest) => {
        return HttpApi.put(`${endpoint}/state`, data);
    };
}
