import { RefObject } from "react";
import { FormActions } from "../../../../../components/forms/form";
import { MouseEvent } from "react";
import { action, observable } from "mobx";
import { FileInfo } from "../../../../../components/controls/files/simpleFilesUpload";

export class QuestionsImportModalStore {
    public formRef?: RefObject<FormActions>;

    @observable public questionsFile?: FileInfo;
    @observable public questionsOptionsFile?: FileInfo;

    @action
    public setQuestionsFile = (value?: FileInfo) => {
        this.questionsFile = value;
    };

    @action
    public setQuestionsOptionsFile = (value?: FileInfo) => {
        this.questionsOptionsFile = value;
    };

    public setFormRef = (formRef: RefObject<FormActions>) => {
        this.formRef = formRef;
    };

    public submit = async (e: MouseEvent, resolve: () => void) => {
        if (!this.formRef!.current!.isValid()) {
            e.preventDefault();
        }

        resolve();
    };
}
