import React from "react";
import { observer } from "mobx-react-lite";
import { FreeTextQuestionStore } from "./freeTextQuestionStore";
import useAsyncEffect from "use-async-effect";
import { FormTextArea } from "../../../../../../components/forms";
import { required } from "../../../../../../components/forms/validations";
import { PropsWithStore } from "../../../../../../typings/customTypings";
import { Col, Row } from "reactstrap";

export const FreeTextQuestion = observer(({ store }: PropsWithStore<FreeTextQuestionStore>) => {
    useAsyncEffect(store.loadData, [store]);

    return (
        <>
            <Row>
                <Col>
                    <span>{store.question}</span>
                </Col>
            </Row>
            <br />
            <br />
            <Row>
                <Col>
                    <FormTextArea
                        label="AnswerLabel"
                        value={store.answer}
                        onChange={store.setAnswer}
                        validations={[required]}
                    />
                </Col>
            </Row>
        </>
    );
});
