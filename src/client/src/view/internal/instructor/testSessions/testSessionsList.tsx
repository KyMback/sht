import { ListGroup, ListGroupItem } from "reactstrap";
import React, { useState } from "react";
import useAsyncEffect from "use-async-effect";
import { TestSessionApi } from "../../../../core/api/testSessionApi";
import { SearchResultBaseFilter, TestSessionListItemDto } from "../../../../typings/dataContracts";
import { CardSectionsGroup } from "../../../../components/layouts/sections/cardSectionsGroup";
import { CardSection, SectionActionProps } from "../../../../components/layouts/sections/cardSection";
import { icons } from "../../../../components/icons/icon";
import { routingStore } from "../../../../stores/routingStore";
import { LinkButton } from "../../../../components/buttons/linkButton";

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
        const result = await TestSessionApi.getListItems(SearchResultBaseFilter.fromJS({
            pageNumber: 1,
            pageSize: 10,
        }));
        setTestSessions(result.items);
    }, []);

    return (
        <CardSectionsGroup>
            <CardSection title="TestSessions" actions={actions}>
                <ListGroup>
                    {testSessions.map((item, index) => (
                        <ListGroupItem key={index}>
                            <LinkButton
                                onClick={() => routingStore.goto(`/test-session/${item.id}`)}
                                title={<>{item.name}</>}/>
                        </ListGroupItem>
                    ))}
                </ListGroup>
            </CardSection>
        </CardSectionsGroup>
    );
};
