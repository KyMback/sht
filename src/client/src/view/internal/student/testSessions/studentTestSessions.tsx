import { observer, useLocalStore } from "mobx-react-lite";
import { StudentTestSessionsStore } from "./studentTestSessionsStore";
import { CardSectionsGroup } from "../../../../components/layouts/sections/cardSectionsGroup";
import { CardSection } from "../../../../components/layouts/sections/cardSection";
import { ListGroup, ListGroupItem } from "reactstrap";
import { LinkButton } from "../../../../components/buttons/linkButton";
import React from "react";
import useAsyncEffect from "use-async-effect";

export const StudentTestSessions = observer(() => {
    const store = useLocalStore(() => new StudentTestSessionsStore());
    useAsyncEffect(store.loadData, []);

    return (
        <CardSectionsGroup>
            <CardSection title="Student_AvailableTestSessions">
                <ListGroup>
                    {store.testSessions.map((item, index) => (
                        <ListGroupItem key={index}>
                            <LinkButton
                                onClick={() => {}}
                                title={<>{item.name}</>}/>
                        </ListGroupItem>
                    ))}
                </ListGroup>
            </CardSection>
        </CardSectionsGroup>
    );
});
