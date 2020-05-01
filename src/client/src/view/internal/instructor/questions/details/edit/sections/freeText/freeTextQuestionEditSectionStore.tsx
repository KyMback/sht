import { action, observable } from "mobx";
import { FreeTextQuestionDto } from "../../../../../../../../typings/dataContracts";

interface RequiredData {
    question: string;
}

export class FreeTextQuestionEditSectionStore {
    @observable question?: string;

    @action
    public setData = (data: RequiredData) => {
        this.question = data.question;
    };

    public getDto = (): FreeTextQuestionDto => {
        return FreeTextQuestionDto.fromJS({
            question: this.question,
        });
    };
}
