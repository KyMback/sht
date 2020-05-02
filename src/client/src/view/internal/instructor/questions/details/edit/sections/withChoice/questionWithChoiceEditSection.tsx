import { PropsWithStore } from "../../../../../../../../typings/customTypings";
import { CardSection } from "../../../../../../../../components/layouts/sections/cardSection";
import React from "react";
import { QuestionWithChoiceEditSectionStore } from "./questionWithChoiceEditSectionStore";
import { DefaultCol } from "../../../../../../../../components/layouts/defaultCol";
import { Button, ListGroup, ListGroupItem, Row } from "reactstrap";
import { FormTextArea } from "../../../../../../../../components/forms";
import { maxLargeLength, required } from "../../../../../../../../components/forms/validations";
import { SubSection } from "../../../../../../../../components/layouts/sections/subSection";
import { Local } from "../../../../../../../../core/localization/local";
import { observer } from "mobx-react-lite";
import { QuestionWithChoiceOptionItem } from "./questionWithChoiceOptionItem";

export const QuestionWithChoiceEditSection = observer(
    ({ store }: PropsWithStore<QuestionWithChoiceEditSectionStore>) => {
        return (
            <CardSection>
                <Row>
                    <DefaultCol>
                        <FormTextArea
                            label="QuestionText"
                            value={store.questionText}
                            onChange={store.setQuestionText}
                            validations={[required, maxLargeLength]}
                        />
                    </DefaultCol>
                </Row>
                <SubSection title="AnswersVariants">
                    <ListGroup>
                        {store.options.map((value, index) => (
                            <QuestionWithChoiceOptionItem key={index} store={value} />
                        ))}
                        <ListGroupItem className="d-flex justify-content-center">
                            <Button color="primary" onClick={store.addNewOption}>
                                <Local id="AddNewAnswerVariant" />
                            </Button>
                        </ListGroupItem>
                    </ListGroup>
                </SubSection>
            </CardSection>
        );
    },
);
