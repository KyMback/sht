import React from "react";
import { Local } from "../../../core/localization/local";
import useAsyncEffect from "use-async-effect";
import { AccountService } from "../../../services/accountService";
import { routingStore } from "../../../stores/routingStore";

export const SignOut = () => {
    useAsyncEffect(async () => {
        try {
            await AccountService.sightOut();
            await AccountService.updateUserContext();
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
