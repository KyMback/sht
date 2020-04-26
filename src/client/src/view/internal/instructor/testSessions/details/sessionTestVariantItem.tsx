import { Col, ListGroupItem, Row } from "reactstrap";
import { ActionIcon } from "../../../../../components/buttons/actionIcon/actionIcon";
import { icons } from "../../../../../components/icons/icon";
import { FormInput, FormSingleSelect } from "../../../../../components/forms";
import { nameShouldBeUniq, required } from "../../../../../components/forms/validations";
import React from "react";
import { TestSessionDetailsEditStore, TestVariant } from "./testSessionDetailsEditStore";
import { observer } from "mobx-react-lite";
import { DefaultCol } from "../../../../../components/layouts/defaultCol";

interface Props {
    store: TestSessionDetailsEditStore;
    data: TestVariant;
}

export const SessionTestVariantItem = observer(({ data, store }: Props) => {
    return (
        <ListGroupItem>
            <div className="d-flex justify-content-end">
                <ActionIcon icon={icons.close} onClick={() => store.removeTestVariant(data)} tooltip="Remove" />
            </div>
            <Row>
                <DefaultCol>
                    <FormInput
                        label="TestSession_TestVariantName"
                        value={data.name}
                        onChange={v => (data.name = v)}
                        validations={[required, nameShouldBeUniq(store.testVariants.map(e => e.name))]}
                    />
                </DefaultCol>
                <DefaultCol>
                    <FormSingleSelect
                        label="TestSession_Variant"
                        isClearable
                        value={data.testVariantId}
                        options={store.testVariantsItems}
                        onChange={v => (data.testVariantId = v)}
                        validations={[required]}
                    />
                </DefaultCol>
            </Row>
        </ListGroupItem>
    );
});
