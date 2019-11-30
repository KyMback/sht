import { History, createBrowserHistory } from "history";

class RoutingStore {
    public history: History;

    constructor() {
        this.history = createBrowserHistory()
    }

    public goto = (path: string) => {
        this.history.push(path);
    }
}

export const routingStore = new RoutingStore();
