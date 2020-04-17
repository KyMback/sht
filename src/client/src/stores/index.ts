import { userContextStore } from "./userContextStore";
import { rootViewStore } from "./rootViewStore";
import { routingStore } from "./routingStore";
import { localStore } from "./localStore";
import { ConfirmationManager } from "../components/modals/confirmationManager";

// Keep all global stores here
export const stores = {
    userContextStore,
    rootViewStore,
    routingStore,
    localStore,
    confirmationManager: new ConfirmationManager(),
};
// for debug purposes
(window as any).stores = stores;
