import React from "react";
import { Local } from "../../../core/localization/local";
import useAsyncEffect from "use-async-effect";
import { AccountApi } from "../../../core/api/accountApi";
import { routingStore } from "../../../stores/routingStore";
import { userContextStore } from "../../../stores/userContextStore";

export const SignOut = () => {
    useAsyncEffect(async () => {
        await AccountApi.sightOut();
        await userContextStore.loadContext();
        routingStore.gotoBase();
    });

    return (
        <div>
            <Local id="SignOut"/>
        </div>
    );
};
