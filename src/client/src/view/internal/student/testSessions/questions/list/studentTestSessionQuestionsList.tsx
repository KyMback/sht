import React, { useContext } from "react";
import { CardSectionsGroup } from "../../../../../../components/layouts/sections/cardSectionsGroup";
import { CardSection } from "../../../../../../components/layouts/sections/cardSection";
import { observer } from "mobx-react-lite";
import { ListGroup, ListGroupItem, ListGroupItemHeading } from "reactstrap";
import { routingStore } from "../../../../../../stores/routingStore";
import { enumeration, EnumLocal, Local } from "../../../../../../core/localization/local";
import { QuestionType } from "../../../../../../typings/dataContracts";
import {
    StudentQuestionsContextStore,
    useStudentQuestionsContext,
} from "../infrasturcture/studentQuestionsContextStore";
import { GuardedActions, GuardsApplier } from "../../../../../../core/guarding";

const topActions: GuardedActions<StudentQuestionsContextStore> = [
    {
        data: store => [
            {
                text: "Back",
                color: "primary",
                onClick: () => routingStore.goto(`/test-session/${store.sessionId}`),
            },
        ],
    },
];

export const StudentTestSessionQuestionsList = observer(() => {
    const context = useStudentQuestionsContext();

    return (
        <CardSectionsGroup
            title={<Local id="TestVariantTemplate" values={{ variant: context.variant }} />}
            topActions={GuardsApplier.applyGuardedArrays(context, topActions)}
        >
            <CardSection title="StudentQuestions_Questions">
                <ListGroup>
                    {context.questionsList.map((item, index) => (
                        <ListGroupItem
                            color={item.isAnswered ? "success" : "secondary"}
                            className="clickable"
                            action
                            key={index}
                            onClick={() => routingStore.goto(`/test-session/${context.sessionId}/questions/${item.id}`)}
                        >
                            <ListGroupItemHeading>{item.order}</ListGroupItemHeading>
                            <EnumLocal enumObject={QuestionType} value={item.type} />
                        </ListGroupItem>
                    ))}
                </ListGroup>
            </CardSection>
        </CardSectionsGroup>
    );
});

enumeration(QuestionType, "QuestionType");
