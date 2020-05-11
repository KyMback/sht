import { PropsWithStore } from "../../../../../../../typings/customTypings";
import { TestSessionVariantQuestionStore } from "./testSessionVariantQuestionStore";
import { observer } from "mobx-react-lite";
import { ListGroupItem, ListGroupItemHeading, Row } from "reactstrap";
import React from "react";
import { DefaultCol } from "../../../../../../../components/layouts/defaultCol";
import { EnumLocal } from "../../../../../../../core/localization/local";
import { QuestionType } from "../../../../../../../typings/dataContracts";

export const TestSessionVariantQuestion = observer(({ store }: PropsWithStore<TestSessionVariantQuestionStore>) => {
    return (
        <ListGroupItem>
            <ListGroupItemHeading>{store.name}</ListGroupItemHeading>
            <Row>
                <DefaultCol>{store.type && <EnumLocal enumObject={QuestionType} value={store.type} />}</DefaultCol>
            </Row>
        </ListGroupItem>
    );
});
