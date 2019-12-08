import { observer, useLocalStore } from "mobx-react-lite";
import { StudentTestSessionsStore } from "./studentTestSessionsStore";
import { CardSectionsGroup } from "../../../../components/layouts/sections/cardSectionsGroup";
import { CardSection } from "../../../../components/layouts/sections/cardSection";
import { ListGroup, ListGroupItem, ListGroupItemHeading } from "reactstrap";
import React from "react";
import useAsyncEffect from "use-async-effect";
import { routingStore } from "../../../../stores/routingStore";
import { dateAndTime } from "../../../../core/utils/dateTimeUtil";

export const StudentTestSessions = observer(() => {
    const store = useLocalStore(() => new StudentTestSessionsStore());
    useAsyncEffect(store.loadData, []);

    return (
        <CardSectionsGroup>
            <CardSection title="Student_AvailableTestSessions">
                <ListGroup>
                    {store.testSessions.map((item, index) => (
                        <ListGroupItem
                            className="clickable"
                            action
                            key={index}
                            onClick={() => routingStore.goto(`/test-session/${item.id}`)}>
                            <ListGroupItemHeading>
                                {item.name}
                            </ListGroupItemHeading>
                            <div>
                                {item.state}
                            </div>
                            <div>
                                {dateAndTime(item.createdAt)}
                            </div>
                        </ListGroupItem>
                    ))}
                </ListGroup>
            </CardSection>
        </CardSectionsGroup>
    );
});
