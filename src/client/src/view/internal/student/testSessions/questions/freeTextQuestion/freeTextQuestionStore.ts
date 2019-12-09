import { observable, runInAction } from "mobx";
import { BaseQuestionStore } from "../infrasturcture/baseQuestionStore";
import { StudentQuestionApi } from "../../../../../../core/api/studentQuestionApi";

export class FreeTextQuestionStore extends BaseQuestionStore {
    @observable public question?: string;
    @observable public answer?: string;

    public loadData = async () => {
        if (this.isDataLoaded) {
            return;
        }

        const question = await StudentQuestionApi.get(this.id);

        runInAction(() => {
            Object.assign(this, question);
            this.isDataLoaded = true;
            this.question = question.text;
        });
    };

    public submit = async () => {
    };
}
