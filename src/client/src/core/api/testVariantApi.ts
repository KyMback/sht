import { Lookup } from "../../typings/dataContracts";
import { HttpApi } from "./http/httpApi";

const endPoint = "/api/test-variant";

export class TestVariantApi {
    public static getLookups = async (): Promise<Array<Lookup>> => {
        return HttpApi.get<Array<Lookup>>(`${endPoint}/lookups`);
    }
}
