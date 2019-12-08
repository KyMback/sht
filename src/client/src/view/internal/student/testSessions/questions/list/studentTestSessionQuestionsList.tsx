import React from "react";
import {
    CardSectionActionConfigs,
    CardSectionsGroup,
} from "../../../../../../components/layouts/sections/cardSectionsGroup";
import { CardSection } from "../../../../../../components/layouts/sections/cardSection";
import { useParams } from "react-router-dom";
import { observer, useLocalStore } from "mobx-react-lite";
import { StudentTestSessionQuestionsListStore } from "./studentTestSessionQuestionsListStore";
import useAsyncEffect from "use-async-effect";
import { ListGroup, ListGroupItem, ListGroupItemHeading } from "reactstrap";
import { routingStore } from "../../../../../../stores/routingStore";
import { enumeration, EnumLocal } from "../../../../../../core/localization/local";
import { QuestionType } from "../../../../../../typings/dataContracts";

interface Params {
    sessionId: string;
}


export const StudentTestSessionQuestionsList = observer(() => {
    const params = useParams<Params>();
    const store = useLocalStore(() => new StudentTestSessionQuestionsListStore(params.sessionId));
    useAsyncEffect(store.loadData, []);

    const actions: Array<CardSectionActionConfigs> = [
        {
            title: "OpenTestDashboard",
            color: "primary",
            onClick: () => routingStore.goto(`/test-session/${params.sessionId}`),
        }
    ];

    return (
        <CardSectionsGroup topActions={actions}>
            <CardSection title="StudentQuestions_Questions">
                <ListGroup>
                    {store.questions.map((item, index) => (
                        <ListGroupItem
                            color={item.isAnswered ? "success" : "secondary"}
                            className="clickable"
                            action
                            key={index}
                            onClick={() => {}}>
                            <ListGroupItemHeading>
                                {item.number}
                            </ListGroupItemHeading>
                            <div>
                                <EnumLocal enumObject={QuestionType} value={item.type}/>
                            </div>
                        </ListGroupItem>
                    ))}
                </ListGroup>
            </CardSection>
        </CardSectionsGroup>
    );
});

enumeration(QuestionType, "QuestionType");
