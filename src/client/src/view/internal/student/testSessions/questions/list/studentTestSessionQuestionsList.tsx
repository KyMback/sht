import React, { useContext } from "react";
import {
    CardSectionActionConfigs,
    CardSectionsGroup,
} from "../../../../../../components/layouts/sections/cardSectionsGroup";
import { CardSection } from "../../../../../../components/layouts/sections/cardSection";
import { observer } from "mobx-react-lite";
import { ListGroup, ListGroupItem, ListGroupItemHeading } from "reactstrap";
import { routingStore } from "../../../../../../stores/routingStore";
import { enumeration, EnumLocal, Local } from "../../../../../../core/localization/local";
import { QuestionType } from "../../../../../../typings/dataContracts";
import { studentQuestionsContext } from "../studentQuestionsModule";

export const StudentTestSessionQuestionsList = observer(() => {
    const store = useContext(studentQuestionsContext)!;
    const actions: Array<CardSectionActionConfigs> = [
        {
            title: "OpenTestDashboard",
            color: "primary",
            onClick: () => routingStore.goto(`/test-session/${store.sessionId}`),
        },
    ];

    return (
        <CardSectionsGroup
            title={<Local id="TestVariantTemplate" values={{ variant: store.variant }} />}
            topActions={actions}
        >
            <CardSection title="StudentQuestions_Questions">
                <ListGroup>
                    {store.questionsList.map((item, index) => (
                        <ListGroupItem
                            color={item.isAnswered ? "success" : "secondary"}
                            className="clickable"
                            action
                            key={index}
                            onClick={() => routingStore.goto(`/test-session/${store.sessionId}/questions/${item.id}`)}
                        >
                            <ListGroupItemHeading>{item.number}</ListGroupItemHeading>
                            <EnumLocal enumObject={QuestionType} value={item.type} />
                        </ListGroupItem>
                    ))}
                </ListGroup>
            </CardSection>
        </CardSectionsGroup>
    );
});

enumeration(QuestionType, "QuestionType");
