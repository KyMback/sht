import React from "react";
import { CardSectionsGroup } from "../../../../components/layouts/sections/cardSectionsGroup";
import { CardSection } from "../../../../components/layouts/sections/cardSection";
import { ListGroup, ListGroupItem, ListGroupItemHeading } from "reactstrap";
import { routingStore } from "../../../../stores/routingStore";
import { icons } from "../../../../components/icons/icon";
import { QuestionType } from "../../../../typings/dataContracts";
import { EnumLocal } from "../../../../core/localization/local";
import { useStoreLifeCycle } from "../../../../core/hooks/useStoreLifeCycle";
import { observer, useLocalStore } from "mobx-react-lite";
import { QuestionsListPageStore } from "./questionsListPageStore";
import { GuardedActions, GuardsApplier } from "../../../../core/guarding";

const actions: GuardedActions<QuestionsListPageStore> = [
    {
        data: store => [
            {
                icon: icons.add,
                onClick: () => routingStore.goto("/questions/add"),
                color: "primary",
            },
            {
                icon: icons.upload,
                color: "primary",
                onClick: store.importData,
            },
        ],
    },
];

export const QuestionsListPage = observer(() => {
    const store = useLocalStore(() => new QuestionsListPageStore());
    useStoreLifeCycle(store);

    return (
        <CardSectionsGroup>
            <CardSection title="Questions" actions={GuardsApplier.applyGuardedArrays(store, actions)}>
                <ListGroup>
                    {store.items.map((item, index) => (
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
                            <div>{item.createdBy.email}</div>
                        </ListGroupItem>
                    ))}
                </ListGroup>
            </CardSection>
        </CardSectionsGroup>
    );
});
