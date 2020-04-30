import React, { useState } from "react";
import useAsyncEffect from "use-async-effect";
import { CardSectionsGroup } from "../../../../components/layouts/sections/cardSectionsGroup";
import { CardSection } from "../../../../components/layouts/sections/cardSection";
import { ListGroup, ListGroupItem, ListGroupItemHeading } from "reactstrap";
import { routingStore } from "../../../../stores/routingStore";
import { HttpApi } from "../../../../core/api/http/httpApi";
import { TableResult } from "../../../../core/api/tableResult";
import { GenericButtonProps } from "../../../../components/buttons/genericButton/genericButton";
import { icons } from "../../../../components/icons/icon";
import { QuestionType } from "../../../../typings/dataContracts";
import { EnumLocal } from "../../../../core/localization/local";

const actions: Array<GenericButtonProps> = [
    {
        icon: icons.add,
        onClick: () => routingStore.goto("/questions/add"),
        color: "primary",
    },
];

export const QuestionsListPage = () => {
    const [testSessions, setTestSessions] = useState<Array<Question>>([]);
    useAsyncEffect(async () => {
        const result = await loadData(1, 100);
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

interface Question {
    id: string;
    createdById: string;
    name: string;
    type: QuestionType;
}

const query = `
query($pageNumber: Int!, $pageSize: Int!) {
  questions(pageNumber: $pageNumber, pageSize: $pageSize) {
    items {
      id
      createdById
      name
      type
    }
    total
  }
}
`;

async function loadData(pageNumber: number, pageSize: number) {
    const { questions } = await HttpApi.graphQl<{ questions: TableResult<Question> }>(query, { pageNumber, pageSize });
    return questions;
}
