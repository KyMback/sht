import { action, observable } from "mobx";
import { TestSessionVariantFreeTextQuestionModificationData } from "../../../../../../../typings/dataContracts";

export interface TestSessionVariantFreeTextQuestionRequiredData {
    questionText: string;
}

export class TestSessionVariantFreeTextQuestionStore {
    @observable questionText?: string;

    @action
    public setData = (data: TestSessionVariantFreeTextQuestionRequiredData) => {
        this.questionText = data.questionText;
    };

    public getDto = (): TestSessionVariantFreeTextQuestionModificationData => {
        return TestSessionVariantFreeTextQuestionModificationData.fromJS({
            questionText: this.questionText,
        });
    };
}
