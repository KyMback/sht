import React from "react";
import { observer, useLocalStore } from "mobx-react-lite";
import { CardSectionsGroup } from "../../../../../components/layouts/sections/cardSectionsGroup";
import { CardSection, SectionActionProps } from "../../../../../components/layouts/sections/cardSection";
import { ListGroup, ListGroupItem, ListGroupItemHeading } from "reactstrap";
import { routingStore } from "../../../../../stores/routingStore";
import { TestVariantsListPageStore } from "./testVariantsListPageStore";
import { icons } from "../../../../../components/icons/icon";
import useAsyncEffect from "use-async-effect";

const actions: Array<SectionActionProps> = [
    {
        icon: icons.add,
        onClick: () => routingStore.goto("/test-variants/add"),
        color: "primary",
    },
];

export const TestVariantsListPage = observer(() => {
    const store = useLocalStore(() => new TestVariantsListPageStore());
    useAsyncEffect(store.loadData, []);

    return (
        <CardSectionsGroup>
            <CardSection title="TestVariants" actions={actions}>
                <ListGroup>
                    {store.testVariants.map((item, index) => (
                        <ListGroupItem
                            key={index}
                            className="clickable"
                            action
                            onClick={() => routingStore.goto(`/test-variants/${item.id}`)}>
                            <ListGroupItemHeading>
                                {item.name}
                            </ListGroupItemHeading>
                            <div>
                                {item.createdByName}
                            </div>
                        </ListGroupItem>
                    ))}
                </ListGroup>
            </CardSection>
        </CardSectionsGroup>
    );
});
