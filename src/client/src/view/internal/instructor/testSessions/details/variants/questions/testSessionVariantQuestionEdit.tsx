import { PropsWithStore } from "../../../../../../../typings/customTypings";
import { TestSessionVariantQuestionStore } from "./testSessionVariantQuestionStore";
import React, { useEffect, useRef } from "react";
import { Form, FormActions } from "../../../../../../../components/forms/form";
import { Col, Row } from "reactstrap";
import { FormSingleSelect } from "../../../../../../../components/forms";
import { observer } from "mobx-react-lite";
import { useStoreLifeCycle } from "../../../../../../../core/hooks/useStoreLifeCycle";

export const TestSessionVariantQuestionEdit = observer(({ store }: PropsWithStore<TestSessionVariantQuestionStore>) => {
    const formRef = useRef<FormActions>(null);
    useEffect(() => {
        store.setFormRef(formRef);
    }, [store]);
    useStoreLifeCycle(store);

    return (
        <Form ref={formRef}>
            <Row>
                <Col>
                    <FormSingleSelect
                        options={store.questions}
                        value={store.sourceQuestionId}
                        onChange={store.setSourceQuestionId}
                    />
                </Col>
            </Row>
        </Form>
    );
});
