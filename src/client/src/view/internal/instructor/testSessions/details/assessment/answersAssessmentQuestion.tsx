import React from "react";
import { PropsWithStore } from "../../../../../../typings/customTypings";
import { AnswersAssessmentQuestionStore } from "./answersAssessmentQuestionStore";
import { observer } from "mobx-react-lite";
import { Col, ListGroupItem, Row } from "reactstrap";
import { ActionIcon } from "../../../../../../components/buttons/actionIcon/actionIcon";
import { icons } from "../../../../../../components/icons/icon";
import { FormMultiSelect, FormTextArea } from "../../../../../../components/forms";
import { required } from "../../../../../../components/forms/validations";

export const AnswersAssessmentQuestion = observer(({ store }: PropsWithStore<AnswersAssessmentQuestionStore>) => {
    return (
        <ListGroupItem>
            <div className="d-flex justify-content-end">
                <ActionIcon icon={icons.close} onClick={store.remove} tooltip="Remove" />
            </div>
            <Row>
                <Col>
                    <FormTextArea
                        label="QuestionText"
                        value={store.questionText}
                        onChange={store.setQuestionText}
                        validations={[required]}
                    />
                </Col>
                <Col>
                    <FormMultiSelect
                        label="QuestionsToAssessment"
                        options={store.variantsQuestions}
                        value={store.questions}
                        onChange={store.setQuestions}
                        validations={[required]}
                    />
                </Col>
            </Row>
        </ListGroupItem>
    );
});
