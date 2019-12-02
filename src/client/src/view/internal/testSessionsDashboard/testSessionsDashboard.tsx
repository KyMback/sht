import { ListGroup, ListGroupItem } from "reactstrap";
import React, { useState } from "react";
import useAsyncEffect from "use-async-effect";
import { TestSessionApi } from "../../../core/api/testSessionApi";
import { SearchResultBaseFilter, TestSessionListItemDto } from "../../../typings/dataContracts";
import { CardSectionsGroup } from "../../../components/layouts/sections/cardSectionsGroup";
import { CardSection } from "../../../components/layouts/sections/cardSection";
import { icons } from "../../../components/icons/icon";

export const TestSessionsDashboard = () => {
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
            <CardSection title="TestSessions" actions={[{
                icon: icons.add,
                onClick: () => {
                },
                color: "primary",
            }]}>
                <ListGroup>
                    {testSessions.map((item, index) => (
                        <ListGroupItem key={index}>{item.name}</ListGroupItem>
                    ))}
                </ListGroup>
            </CardSection>
        </CardSectionsGroup>
    );
};
