import { PropsWithStore } from "../../../../../../../typings/customTypings";
import { TestSessionVariantQuestionStore } from "./testSessionVariantQuestionStore";
import { observer } from "mobx-react-lite";
import { ListGroupItem, ListGroupItemHeading, Row } from "reactstrap";
import React from "react";
import { DefaultCol } from "../../../../../../../components/layouts/defaultCol";
import { EnumLocal } from "../../../../../../../core/localization/local";
import { QuestionType } from "../../../../../../../typings/dataContracts";
import { ActionIcon } from "../../../../../../../components/buttons/actionIcon/actionIcon";
import { icons } from "../../../../../../../components/icons/icon";

export const TestSessionVariantQuestion = observer(({ store }: PropsWithStore<TestSessionVariantQuestionStore>) => {
    return (
        <ListGroupItem>
            <div className="d-flex justify-content-between">
                <ListGroupItemHeading>{store.name}</ListGroupItemHeading>
                <ActionIcon icon={icons.close} onClick={store.remove} tooltip="Remove" />
            </div>
            <Row>
                <DefaultCol>{store.type && <EnumLocal enumObject={QuestionType} value={store.type} />}</DefaultCol>
            </Row>
        </ListGroupItem>
    );
});
