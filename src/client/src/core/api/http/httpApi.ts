import { rootViewStore } from "../../../stores/rootViewStore";
import { ApiError } from "./apiError";
import * as queryString from "querystring";

interface Options {
    url: string;
    method: "GET" | "POST" | "PUT" | "DELETE";
    body?: any;
}

const apiConstants = {
    headers: {
        errorCode: "X-ERROR-CODE",
        errorId: "X-ERROR-ID",
        payloadError: "X-ERROR-PAYLOAD",
    },
};

interface GraphQlResponse<TData> {
    data: TData;
}

export class HttpApi {
    public static graphQl = async <TData extends any>(query: string, variables?: any): Promise<GraphQlResponse<TData>> => {
        return HttpApi.request<GraphQlResponse<TData>>({
            method: "POST",
            url: "/graphql",
            body: {
                variables,
                query,
            },
        });
    };

    public static get = async <TData extends any>(url: string, query?: any): Promise<TData> => {
        return HttpApi.request<TData>({
            method: "GET",
            url: query ? `${url}?${queryString.stringify(query)}` : url,
        });
    };

    public static post = async <TData extends any>(url: string, body?: any): Promise<TData> => {
        return HttpApi.request<TData>({
            method: "POST",
            url: url,
            body: body,
        });
    };

    public static put = async <TData extends any>(url: string, body?: any): Promise<TData> => {
        return HttpApi.request<TData>({
            method: "PUT",
            url: url,
            body: body,
        });
    };

    public static delete = async <TData extends any>(url: string): Promise<TData> => {
        return HttpApi.request<TData>({
            method: "DELETE",
            url: url,
        });
    };

    private static request = async <TData extends any>(options: Options): Promise<TData> => {
        HttpApi.toggleLoading(true);
        let response: Response;
        try {
            response = await fetch(options.url, {
                method: options.method,
                body: HttpApi.getBody(options),
                credentials: "same-origin",
                headers: {
                    "Content-Type": "application/json",
                    Accept: "application/json",
                },
            });
        } finally {
            HttpApi.toggleLoading(false);
        }

        return await HttpApi.parseResponse<TData>(response);
    };

    private static getBody = (options: Options) => {
        return options.body && JSON.stringify(options.body);
    };

    private static parseResponse = async <TData extends any>(response: Response): Promise<TData> => {
        if (!response.ok) {
            HttpApi.handleError(response);
        }

        const text = await response.text();
        return text ? JSON.parse(text) : {};
    };

    private static handleError = (response: Response) => {
        const errorCode = response.headers.get(apiConstants.headers.errorCode) as string;
        const errorId = response.headers.get(apiConstants.headers.errorId) as string;
        const payloadError = response.headers.get(apiConstants.headers.payloadError);

        throw new ApiError(response, errorCode, errorId, payloadError ? JSON.parse(payloadError) : {});
    };

    private static toggleLoading(show: boolean) {
        if (show) {
            rootViewStore.showLoading();
        } else {
            rootViewStore.hideLoading();
        }
    }
}
