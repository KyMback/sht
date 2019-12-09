import { observable, runInAction } from "mobx";
import { BaseQuestionStore } from "../infrasturcture/baseQuestionStore";

export class FreeTextQuestionStore extends BaseQuestionStore {
    @observable public question?: string;
    @observable public answer?: string;

    public loadData = async () => {
        runInAction(() => {

        });
    };

    public submit = async () => {
    };
}
