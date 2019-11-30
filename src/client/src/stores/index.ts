import { userContextStore } from "./userContextStore";
import { rootViewStore } from "./rootViewStore";
import { routingStore } from "./routingStore";
import { localStore } from "./localStore";

// Keep all global stores here
const stores = {
    userContextStore,
    rootViewStore,
    routingStore,
    localStore,
};
// for debug purposes
(window as any).stores = stores;
