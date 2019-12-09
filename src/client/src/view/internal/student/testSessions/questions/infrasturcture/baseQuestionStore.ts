import { observable } from "mobx";
import { QuestionType } from "../../../../../../typings/dataContracts";

export abstract class BaseQuestionStore {
    @observable public id: string;
    @observable public number?: string;
    @observable public type?: QuestionType;

    constructor(id: string, type: QuestionType) {
        this.id = id;
        this.type = type;
    }

    public abstract loadData: () => Promise<any>;
    public abstract submit: () => Promise<any>;
}
