import { observable } from "mobx";
import { QuestionType } from "../../../../../../typings/dataContracts";

export abstract class BaseQuestionStore {
    @observable public id: string;
    @observable public sessionId: string;
    @observable public number?: string;
    @observable public type?: QuestionType;
    @observable public isDataLoaded: boolean;

    constructor(id: string, sessionId: string, type: QuestionType) {
        this.id = id;
        this.sessionId = sessionId;
        this.type = type;
        this.isDataLoaded = false;
    }

    public abstract loadData: () => Promise<any>;
    public abstract submit: () => Promise<any>;
}

