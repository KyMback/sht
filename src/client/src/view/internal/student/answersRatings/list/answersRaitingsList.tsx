import useAsyncEffect from "use-async-effect";
import { CardSectionsGroup } from "../../../../../components/layouts/sections/cardSectionsGroup";
import { CardSection } from "../../../../../components/layouts/sections/cardSection";
import { ListGroup, ListGroupItem, ListGroupItemHeading } from "reactstrap";
import { routingStore } from "../../../../../stores/routingStore";
import React, { useState } from "react";
import { TableResult } from "../../../../../core/api/tableResult";
import { HttpApi } from "../../../../../core/api/http/httpApi";

export const AnswersRatingsList = () => {
    const [items, setItems] = useState<Array<AnswerRating>>([]);
    useAsyncEffect(async () => {
        const result = await loadData(1, 10);
        setItems(result.items);
    }, []);

    return (
        <CardSectionsGroup>
            <CardSection title="AvailableAnswersRatings">
                <ListGroup>
                    {items.map((item, index) => (
                        <ListGroupItem
                            className="clickable"
                            action
                            key={index}
                            onClick={() => routingStore.goto(`/answers-ratings/${item.id}`)}
                        >
                            <ListGroupItemHeading>{item.questionText}</ListGroupItemHeading>
                        </ListGroupItem>
                    ))}
                </ListGroup>
            </CardSection>
        </CardSectionsGroup>
    );
};

interface AnswerRating {
    id: string;
    questionText: string;
}

const query = `
query q($pageNumber: Int!, $pageSize: Int!) {
  answerRatings(pageNumber: $pageNumber, pageSize: $pageSize) {
    items {
      id
      questionText
    }
  }
}`;

async function loadData(pageNumber: number, pageSize: number): Promise<TableResult<AnswerRating>> {
    const { answerRatings } = await HttpApi.graphQl<{ answerRatings: TableResult<AnswerRating> }>(query, {
        pageNumber,
        pageSize,
    });
    return answerRatings;
}
