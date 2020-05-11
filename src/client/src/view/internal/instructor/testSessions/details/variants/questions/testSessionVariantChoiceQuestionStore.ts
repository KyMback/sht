import { action, observable } from "mobx";
import {
    TestSessionVariantChoiceQuestionModificationData,
    TestSessionVariantChoiceQuestionOptionModificationData,
} from "../../../../../../../typings/dataContracts";

export interface TestSessionVariantChoiceQuestionRequiredData {
    questionText: string;
    options: Array<Option>;
}

interface Option {
    id?: string;
    text: string;
    isCorrect: boolean;
}

export class TestSessionVariantChoiceQuestionStore {
    @observable public questionText?: string;
    @observable public options: Array<TestSessionVariantChoiceQuestionOptionModificationData> = [];

    @action
    public setData = (data: TestSessionVariantChoiceQuestionRequiredData) => {
        this.questionText = data.questionText;
        this.options = data.options.map(e => TestSessionVariantChoiceQuestionOptionModificationData.fromJS(e));
    };

    public getDto = (): TestSessionVariantChoiceQuestionModificationData => {
        return TestSessionVariantChoiceQuestionModificationData.fromJS({
            questionText: this.questionText,
            options: this.options,
        });
    };
}
