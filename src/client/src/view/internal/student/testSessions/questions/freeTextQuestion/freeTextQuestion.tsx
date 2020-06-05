import React from "react";
import { observer } from "mobx-react-lite";
import { FreeTextQuestionStore } from "./freeTextQuestionStore";
import { FormTextArea } from "../../../../../../components/forms";
import { required } from "../../../../../../components/forms/validations";
import { PropsWithStore } from "../../../../../../typings/customTypings";
import { Col, Row } from "reactstrap";
import { useStoreLifeCycle } from "../../../../../../core/hooks/useStoreLifeCycle";
import { ImagesPreview } from "../../../../../../components/images/imagesPreview";

export const FreeTextQuestion = observer(({ store }: PropsWithStore<FreeTextQuestionStore>) => {
    useStoreLifeCycle(store);

    return (
        <>
            <Row>
                <Col>
                    <span>{store.question}</span>
                </Col>
            </Row>
            <Row>
                <Col>
                    <ImagesPreview images={store.images} />
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
