import { action, computed, observable, runInAction } from "mobx";
import { icons } from "../../../../../../components/icons/icon";
import { pull } from "lodash";
import {
    TestSessionVariantQuestionRequiredData,
    TestSessionVariantQuestionStore,
} from "./questions/testSessionVariantQuestionStore";
import { ConfirmationsService } from "../../../../../../services/common/confirmations/confirmationsService";
import React from "react";
import { TestSessionVariantQuestionEdit } from "./questions/testSessionVariantQuestionEdit";
import { TestSessionVariantModificationData } from "../../../../../../typings/dataContracts";

export interface TestSessionVariantRequiredData {
    id: string;
    name: string;
    isRandomOrder: boolean;
    questions: Array<TestSessionVariantQuestionRequiredData>;
}

export class TestSessionVariantStore {
    @observable public isExpanded: boolean = false;

    @observable public id?: string;
    @observable public name?: string = "Test Variant Name";
    @observable public isRandomOrder: boolean = false;
    @observable public questions: Array<TestSessionVariantQuestionStore> = [];

    @computed
    public get expandIcon() {
        return this.isExpanded ? icons.unExpand : icons.expand;
    }

    @action public setName = (value?: string) => (this.name = value);
    @action public toggleExpand = () => (this.isExpanded = !this.isExpanded);
    @action public setIsRandomOrder = (value: boolean) => (this.isRandomOrder = value);

    constructor(private deleteHandler: (toRemove: TestSessionVariantStore) => void, isExpanded = false) {
        this.isExpanded = isExpanded;
    }

    public remove = () => {
        this.deleteHandler(this);
    };

    @action
    public removeQuestion = (toRemove: TestSessionVariantQuestionStore) => {
        pull(this.questions, toRemove);
    };

    @action
    public addQuestion = async () => {
        const tmpQuestion = new TestSessionVariantQuestionStore(this.removeQuestion);
        const result = await ConfirmationsService.show({
            title: "AddNewQuestion",
            body: <TestSessionVariantQuestionEdit store={tmpQuestion} />,
            actions: [
                {
                    color: "secondary",
                    title: "Cancel",
                    onClick: (_, resolve) => tmpQuestion.cancelEdit(resolve),
                },
                {
                    color: "primary",
                    title: "Add",
                    onClick: (e, resolve) => tmpQuestion.update(e, resolve),
                },
            ],
        });

        if (result) {
            runInAction(() => {
                this.questions.push(tmpQuestion);
            });
        }
    };

    @action
    public setData = (data: TestSessionVariantRequiredData) => {
        this.name = data.name;
        this.id = data.id;
        this.isRandomOrder = data.isRandomOrder;
        this.questions = data.questions.map(e => {
            const st = new TestSessionVariantQuestionStore(this.removeQuestion);
            st.setData(e);
            return st;
        });
    };

    public getDto = (): TestSessionVariantModificationData => {
        return TestSessionVariantModificationData.fromJS({
            id: this.id,
            name: this.name,
            isRandomOrder: this.isRandomOrder,
            questions: this.questions.map(e => e.getDto()),
        });
    };
}
