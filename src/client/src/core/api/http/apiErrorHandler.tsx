import React, { useEffect } from "react";
import { ApiError } from "./apiError";
import { routingStore } from "../../../stores/routingStore";
import { notifications } from "../../../components/notifications/notifications";
import { Local } from "../../localization/local";

interface Props {
    children: JSX.Element;
}

export const ApiErrorHandler = ({ children }: Props) => {
    useEffect(() => {
        const listener = (event: PromiseRejectionEvent) => onUnhandledRejection(event);

        window.addEventListener("unhandledrejection", listener);
        return () => window.removeEventListener("unhandledrejection", listener);
    }, []);

    return children;
};

const onUnhandledRejection = (event: PromiseRejectionEvent): void => {
    const error = event.reason;
    if (error instanceof (ApiError)) {
        handleApiError(error);
    }
};

const handleApiError = (error: ApiError): void => {
    if (error.response.status === 401) {
        handleUnauthorized();
        return;
    }

    notifications.error(<Local id="UnexpectedErrorHappened" values={error}/>);
};

const handleUnauthorized = (): void => {
    routingStore.goto("/login");
};
