import { userContextStore } from "./userContextStore";
import { rootViewStore } from "./rootViewStore";
import { routingStore } from "./routingStore";

// Keep all global stores here
const stores = {
    contextStore: userContextStore,
    rootViewStore,
    routingStore,
};
// for debug purposes
(window as any).stores = stores;
