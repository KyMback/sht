import React, { useEffect, useRef } from "react";
import { FormSingleSelect } from "../../../components/forms";
import { required } from "../../../components/forms/validations";
import { Form, FormActions } from "../../../components/forms/form";
import { StartStudentTestConfirmationStore } from "./startStudentTestConfirmationStore";
import { observer } from "mobx-react-lite";
import { PropsWithStore } from "../../../typings/customTypings";
import { useStoreLifeCycle } from "../../../core/hooks/useStoreLifeCycle";

export const StartStudentTestConfirmationBody = observer(
    ({ store }: PropsWithStore<StartStudentTestConfirmationStore>) => {
        const formRef = useRef<FormActions>(null);
        useEffect(() => {
            store.setFormRef(formRef);
        }, [store]);
        useStoreLifeCycle(store);

        return (
            <Form ref={formRef}>
                <FormSingleSelect
                    label="StudentTestSession_ChooseVariant"
                    options={store.variants}
                    value={store.variantId}
                    onChange={store.setVariant}
                    validations={[required]}
                />
            </Form>
        );
    },
);
