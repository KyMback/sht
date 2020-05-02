import { action, observable } from "mobx";
import { ChoiceQuestionOptionDto } from "../../../../../../../../typings/dataContracts";

export interface QuestionWithChoiceOptionData {
    id: string;
    text: string;
    isCorrect: boolean;
}

export class QuestionWithChoiceOptionStore {
    @observable id?: string;
    @observable text?: string;
    @observable isCorrect: boolean = false;

    constructor(private onDelete: (data: QuestionWithChoiceOptionStore) => void) {}

    public delete = () => this.onDelete(this);

    @action
    public setText = (value?: string) => {
        this.text = value;
    };

    @action
    public setIsCorrect = (value: boolean) => {
        this.isCorrect = value;
    };

    @action
    public setData = (data: QuestionWithChoiceOptionData) => {
        this.id = data.id;
        this.text = data.text;
        this.isCorrect = data.isCorrect;
    };

    public getDto = (): ChoiceQuestionOptionDto => {
        return ChoiceQuestionOptionDto.fromJS({
            id: this.id,
            text: this.text,
            isCorrect: this.isCorrect,
        });
    };
}
