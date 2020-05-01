import { action, observable } from "mobx";

interface RequiredData {
    question: string;
}

export class FreeTextQuestionViewSectionStore {
    @observable question?: string;

    @action
    public setData = ({ question }: RequiredData) => {
        this.question = question;
    };
}
