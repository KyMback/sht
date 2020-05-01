import React, { useState } from "react";
import useAsyncEffect from "use-async-effect";
import { CardSectionsGroup } from "../../../../components/layouts/sections/cardSectionsGroup";
import { CardSection } from "../../../../components/layouts/sections/cardSection";
import { ListGroup, ListGroupItem, ListGroupItemHeading } from "reactstrap";
import { routingStore } from "../../../../stores/routingStore";
import { GenericButtonProps } from "../../../../components/buttons/genericButton/genericButton";
import { icons } from "../../../../components/icons/icon";
import { QuestionType } from "../../../../typings/dataContracts";
import { EnumLocal } from "../../../../core/localization/local";
import { QuestionListItem, QuestionsActionsService } from "../../../../services/questions/questionsActionsService";

const actions: Array<GenericButtonProps> = [
    {
        icon: icons.add,
        onClick: () => routingStore.goto("/questions/add"),
        color: "primary",
    },
];

export const QuestionsListPage = () => {
    const [testSessions, setTestSessions] = useState<Array<QuestionListItem>>([]);
    useAsyncEffect(async () => {
        const result = await QuestionsActionsService.getListItems(1, 100);
        setTestSessions(result.items);
    }, []);

    return (
        <CardSectionsGroup>
            <CardSection title="Questions" actions={actions}>
                <ListGroup>
                    {testSessions.map((item, index) => (
                        <ListGroupItem
                            key={index}
                            className="clickable"
                            action
                            onClick={() => routingStore.goto(`/questions/${item.id}`)}
                        >
                            <ListGroupItemHeading>{item.name}</ListGroupItemHeading>
                            <div>
                                <EnumLocal enumObject={QuestionType} value={item.type} />
                            </div>
                        </ListGroupItem>
                    ))}
                </ListGroup>
            </CardSection>
        </CardSectionsGroup>
    );
};
