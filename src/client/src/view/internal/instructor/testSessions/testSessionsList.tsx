import { ListGroup, ListGroupItem, ListGroupItemHeading } from "reactstrap";
import React, { useState } from "react";
import useAsyncEffect from "use-async-effect";
import { TestSessionApi } from "../../../../core/api/testSessionApi";
import { SearchResultBaseFilter, TestSessionListItemDto } from "../../../../typings/dataContracts";
import { CardSectionsGroup } from "../../../../components/layouts/sections/cardSectionsGroup";
import { CardSection, SectionActionProps } from "../../../../components/layouts/sections/cardSection";
import { icons } from "../../../../components/icons/icon";
import { routingStore } from "../../../../stores/routingStore";
import { dateAndTime } from "../../../../core/utils/dateTimeUtil";

const actions: Array<SectionActionProps> = [
    {
        icon: icons.add,
        onClick: () => routingStore.goto("/test-session/add"),
        color: "primary",
    },
];

export const TestSessionsList = () => {
    const [testSessions, setTestSessions] = useState<Array<TestSessionListItemDto>>([]);
    useAsyncEffect(async () => {
        const result = await TestSessionApi.getListItems(
            SearchResultBaseFilter.fromJS({
                pageNumber: 1,
                pageSize: 100,
            }),
        );
        setTestSessions(result.items);
    }, []);

    return (
        <CardSectionsGroup>
            <CardSection title="TestSessions" actions={actions}>
                <ListGroup>
                    {testSessions.map((item, index) => (
                        <ListGroupItem
                            key={index}
                            className="clickable"
                            action
                            onClick={() => routingStore.goto(`/test-session/${item.id}`)}
                        >
                            <ListGroupItemHeading>{item.name}</ListGroupItemHeading>
                            <div>{item.state}</div>
                            <div>{dateAndTime(item.createdAt)}</div>
                        </ListGroupItem>
                    ))}
                </ListGroup>
            </CardSection>
        </CardSectionsGroup>
    );
};
