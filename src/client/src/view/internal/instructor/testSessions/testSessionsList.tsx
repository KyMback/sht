import { ListGroup, ListGroupItem, ListGroupItemHeading } from "reactstrap";
import React, { useState } from "react";
import useAsyncEffect from "use-async-effect";
import { TestSessionListItemDto } from "../../../../typings/dataContracts";
import { CardSectionsGroup } from "../../../../components/layouts/sections/cardSectionsGroup";
import { CardSection } from "../../../../components/layouts/sections/cardSection";
import { icons } from "../../../../components/icons/icon";
import { routingStore } from "../../../../stores/routingStore";
import { dateAndTime } from "../../../../core/utils/dateTimeUtil";
import { HttpApi } from "../../../../core/api/http/httpApi";
import { TableResult } from "../../../../core/api/tableResult";
import { GenericButtonProps } from "../../../../components/buttons/genericButton/genericButton";

const actions: Array<GenericButtonProps> = [
    {
        icon: icons.add,
        onClick: () => routingStore.goto("/test-session/add"),
        color: "primary",
    },
];

export const TestSessionsList = () => {
    const [testSessions, setTestSessions] = useState<Array<TestSessionListItemDto>>([]);
    useAsyncEffect(async () => {
        const result = await loadData(1, 100);
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
                            onClick={() => routingStore.goto(`/test-session/dashboard/${item.id}`)}
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

async function loadData(pageNumber: number, pageSize: number) {
    const query = `
{
  items:testSessionListItems(pageNumber: ${pageNumber}, pageSize:${pageSize}, order_by:{createdAt:DESC}) {
    items {
      id
      createdAt
      name
      state
    }
    total
  }
}
        `;
    const { items } = await HttpApi.graphQl<{ items: TableResult<TestSessionListItemDto> }>(query);
    return items;
}
