import { observer } from "mobx-react-lite";
import { PropsWithStore } from "../../../../../../typings/customTypings";
import React from "react";
import { ChoiceQuestionStore } from "./choiceQuestionStore";
import { Col, Label, Row } from "reactstrap";
import { useStoreLifeCycle } from "../../../../../../core/hooks/useStoreLifeCycle";
import { Checkbox } from "../../../../../../components/controls/checkbox/checkbox";

export const ChoiceQuestion = observer(({ store }: PropsWithStore<ChoiceQuestionStore>) => {
    useStoreLifeCycle(store);

    return (
        <>
            <Row>
                <Col>
                    <span>{store.question}</span>
                </Col>
            </Row>
            <br />
            <Row>
                <Col className="d-flex flex-column">
                    {store.options.map((value, index) => (
                        <Label key={index} className="d-flex">
                            <Checkbox value={value.isChecked} onChange={() => (value.isChecked = !value.isChecked)} />
                            <span className="overflow-auto">{value.text}</span>
                        </Label>
                    ))}
                </Col>
            </Row>
        </>
    );
});
