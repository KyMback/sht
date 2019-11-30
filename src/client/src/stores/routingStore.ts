import { History, createBrowserHistory } from "history";

class RoutingStore {
    public history: History;
    public basePath: string = "/";

    constructor() {
        this.history = createBrowserHistory();
    }

    public goto = (path: string) => {
        this.history.push(path);
    };

    public gotoBase = () => {
        this.history.push(this.basePath);
    };
}

export const routingStore = new RoutingStore();
