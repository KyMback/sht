import useAsyncEffect from "use-async-effect";
import { useLocation } from "react-router-dom";
import { routingStore } from "../../../stores/routingStore";
import React from "react";
import { AccountApi } from "../../../core/api/accountApi";
import { apiErrors, isExpected } from "../../../core/api/http/apiError";
import { notifications } from "../../../components/notifications/notifications";
import * as queryString from "querystring";

export const EmailConfirmationPage = () => {
    const loc = useLocation();
    const data = queryString.parse(loc.search.slice(1));
    useAsyncEffect(async () => confirmAccount(data["email"] as string, data["token"] as string), []);

    return <></>;
};

const confirmAccount = async (email: string, token: string) => {
    try {
        await AccountApi.confirmEmail(email, token);
        notifications.success("EmailSuccessfullyConfirmed");
    } catch (e) {
        if (isExpected(e, apiErrors.invalidEmailConfirmationToken)) {
            notifications.errorCode(apiErrors.invalidEmailConfirmationToken);
        } else {
            throw e;
        }
    } finally {
        routingStore.gotoBase();
    }
};
