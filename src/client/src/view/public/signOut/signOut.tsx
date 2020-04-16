import React from "react";
import { Local } from "../../../core/localization/local";
import useAsyncEffect from "use-async-effect";
import { AccountService } from "../../../services/accountService";
import { routingStore } from "../../../stores/routingStore";
import { userContextStore } from "../../../stores/userContextStore";

export const SignOut = () => {
    useAsyncEffect(async () => {
        try {
            await AccountService.sightOut();
            await userContextStore.loadContext();
        } finally {
            routingStore.gotoBase();
        }
    });

    return (
        <div>
            <Local id="SignOut" />
        </div>
    );
};
