import { rootViewStore } from "../../stores/rootViewStore";

interface Options {
    url: string;
    method: "GET" | "POST" | "PUT" | "DELETE";
    body?: any;
}

export class HttpApi {
    public static get = async <TData extends any>(url: string): Promise<TData> => {
        return HttpApi.request<TData>({
            method: "GET",
            url: url,
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
        const response = await fetch(options.url, {
            method: options.method,
            body: options.body && JSON.stringify(options.body),
            headers: {
                "Content-Type": "application/json",
            },
        });
        HttpApi.toggleLoading(false);

        if (response.ok) {
            return await response.json() as TData;
        } else {
            throw new Error();
        }
    };

    private static toggleLoading(show: boolean) {
        if (show) {
            rootViewStore.showLoading();
        } else {
            rootViewStore.hideLoading();
        }
    }
}
