import { observer, useLocalStore } from "mobx-react-lite";
import { IdParams } from "../../../../../typings/customTypings";
import { AnswersRatingsDetailsStore } from "./answersRatingsDetailsStore";
import React from "react";
import { useParams } from "react-router-dom";
import { useStoreLifeCycle } from "../../../../../core/hooks/useStoreLifeCycle";
import { CardSectionsGroup } from "../../../../../components/layouts/sections/cardSectionsGroup";
import { CardSection } from "../../../../../components/layouts/sections/cardSection";
import { Col, ListGroup, ListGroupItem, Row } from "reactstrap";
import { GuardedActions, GuardsApplier } from "../../../../../core/guarding";
import { LabeledText } from "../../../../../components/labels/labeled";
import { Local } from "../../../../../core/localization/local";
import { FormNumericInput } from "../../../../../components/forms";
import { required } from "../../../../../components/forms/validations";
import { Form } from "../../../../../components/forms/form";

export const AnswersRatingsDetails = observer(() => {
    const { id } = useParams<IdParams>();
    const store = useLocalStore(() => new AnswersRatingsDetailsStore(id!));
    useStoreLifeCycle(store);

    return (
        <Form onValidSubmit={store.save}>
            <CardSectionsGroup title="AnswersRating" topActions={GuardsApplier.applyGuardedArrays(store, actions)}>
                <CardSection>
                    <Row>
                        <Col>
                            <LabeledText title="QuestionText" value={store.questionText} />
                        </Col>
                    </Row>
                    <ListGroup>
                        <h4>
                            <Local id="Answers" />
                        </h4>
                        {store.orderedRatingItems.map((item, index) => (
                            <ListGroupItem key={index}>
                                <Row>
                                    <Col xs={1}>
                                        <FormNumericInput
                                            value={item.rating}
                                            onChange={value => store.setRating(item, value)}
                                            validations={[required]}
                                        />
                                    </Col>
                                    <Col>
                                        <span>{item.answer.freeTextAnswer.answer}</span>
                                    </Col>
                                </Row>
                            </ListGroupItem>
                        ))}
                    </ListGroup>
                </CardSection>
            </CardSectionsGroup>
        </Form>
    );
});

const actions: GuardedActions<AnswersRatingsDetailsStore> = [
    {
        guard: store => store.canSave,
        data: _ => [
            {
                text: "Save",
                color: "primary",
            },
        ],
    },
];
