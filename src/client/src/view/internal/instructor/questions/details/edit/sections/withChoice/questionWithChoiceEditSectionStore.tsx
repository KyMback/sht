import { action, observable } from "mobx";
import { QuestionWithChoiceOptionData, QuestionWithChoiceOptionStore } from "./questionWithChoiceOptionStore";
import { ChoiceQuestionDto } from "../../../../../../../../typings/dataContracts";
import { pull } from "lodash";

interface RequiredData {
    questionText: string;
    options: Array<QuestionWithChoiceOptionData>;
}

export class QuestionWithChoiceEditSectionStore {
    @observable public questionText?: string;
    @observable public options: Array<QuestionWithChoiceOptionStore> = [];

    @action
    public setQuestionText = (value?: string) => {
        this.questionText = value;
    };

    @action
    public addNewOption = () => {
        this.options.push(new QuestionWithChoiceOptionStore(this.deleteOption));
    };

    @action
    public setData = (data: RequiredData) => {
        this.questionText = data.questionText;
        this.options = data.options.map(e => {
            const store = new QuestionWithChoiceOptionStore(this.deleteOption);
            store.setData(e);
            return store;
        });
    };

    private deleteOption = (toDelete: QuestionWithChoiceOptionStore) => {
        pull(this.options, toDelete);
    };

    public getDto = (): ChoiceQuestionDto => {
        return ChoiceQuestionDto.fromJS({
            questionText: this.questionText,
            options: this.options.map(e => e.getDto()),
        });
    };
}
