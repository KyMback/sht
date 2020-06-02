import { observer } from "mobx-react-lite";
import { PropsWithStore } from "../../../../../typings/customTypings";
import React, { useEffect, useRef } from "react";
import { QuestionsImportModalStore } from "./questionsImportModalStore";
import { Form, FormActions } from "../../../../../components/forms/form";
import { FormSimpleSingleFileUpload } from "../../../../../components/forms";
import { required } from "../../../../../components/forms/validations";

export const QuestionsImportModal = observer(({ store }: PropsWithStore<QuestionsImportModalStore>) => {
    const formRef = useRef<FormActions>(null);

    useEffect(() => {
        store.setFormRef(formRef);
    });

    return (
        <Form ref={formRef}>
            <FormSimpleSingleFileUpload
                label="QuestionTemplatesFile"
                accept=".csv"
                onChange={store.setQuestionsFile}
                value={store.questionsFile}
                validations={[required]}
            />
            <FormSimpleSingleFileUpload
                label="ChoiceQuestionTemplateOptionsFile"
                accept=".csv"
                onChange={store.setQuestionsOptionsFile}
                value={store.questionsOptionsFile}
            />
        </Form>
    );
});
