import {
    CreatedEntityResponse,
    TestSessionDetailsDto,
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

    public static stateTransition = async (data: TestSessionStateTransitionRequest) => {
        return HttpApi.put(`${endpoint}/state`, data);
    };
}
