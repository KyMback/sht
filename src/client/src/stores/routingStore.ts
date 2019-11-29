import { History, createBrowserHistory } from "history";

class RoutingStore {
    public history: History;

    constructor() {
        this.history = createBrowserHistory()
    }
}

export const routingStore = new RoutingStore();
