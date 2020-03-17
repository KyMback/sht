import {
    CardSectionActionConfigs,
    CardSectionsGroup,
} from "../../../../../components/layouts/sections/cardSectionsGroup";
import { CardSection } from "../../../../../components/layouts/sections/cardSection";
import React from "react";
import { observer, useLocalStore } from "mobx-react-lite";
import { TestSessionDetailsEditStore } from "./testSessionDetailsEditStore";
import { Form } from "../../../../../components/forms/form";
import { FormInput, FormMultiSelect } from "../../../../../components/forms";
import { required } from "../../../../../components/forms/validations";
import useAsyncEffect from "use-async-effect";
import { ListGroup } from "reactstrap";
import { icons } from "../../../../../components/icons/icon";
import { SessionTestVariantItem } from "./sessionTestVariantItem";
import { useParams } from "react-router-dom";
import { IdParams } from "../../../../../typings/customTypings";

export const TestSessionEditDetails = observer(() => {
    const params = useParams<IdParams>();
    const store = useLocalStore(() => new TestSessionDetailsEditStore(params.id));
    useAsyncEffect(store.loadData, []);
    const actions: Array<CardSectionActionConfigs> = [
        {
            title: "Cancel",
            color: "secondary",
            onClick: store.cancel,
        },
        {
            title: "Save",
            color: "primary",
        },
    ];

    return (
        <Form onValidSubmit={store.save}>
            <CardSectionsGroup actions={actions}>
                <CardSection title="TestSession_Details">
                    <FormInput
                        label="TestSession_Name"
                        value={store.name}
                        onChange={store.setName}
                        validations={[required]}
                    />
                    <FormMultiSelect
                        label="TestSession_StudentGroups"
                        value={store.selectedGroups}
                        options={store.groups}
                        onChange={store.setSelectedGroups}
                        validations={[required]}
                    />
                </CardSection>
                <CardSection
                    title="TestSession_TestVariants"
                    actions={[
                        {
                            color: "primary",
                            icon: icons.add,
                            onClick: store.addNewTestVariant,
                        },
                    ]}
                >
                    <ListGroup>
                        {store.testVariants.map((tv, index) => (
                            <SessionTestVariantItem key={index} data={tv} store={store} />
                        ))}
                    </ListGroup>
                </CardSection>
            </CardSectionsGroup>
        </Form>
    );
});
