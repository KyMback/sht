import { observer } from "mobx-react-lite";
import React from "react";
import { ConfirmationModal } from "./confirmationModal";
import { PropsWithStore } from "../../typings/customTypings";
import { ConfirmationManager } from "./confirmationManager";

export const ConfirmationContainer = observer(({ store }: PropsWithStore<ConfirmationManager>) => {
    if (!store.isOpen) {
        return null;
    }

    return <ConfirmationModal {...store.details!} isOpen={store.isOpen} hide={store.hide} />;
});
