import {
    CardSectionActionConfigs,
    CardSectionsGroup,
} from "../../../../../components/layouts/sections/cardSectionsGroup";
import { CardSection } from "../../../../../components/layouts/sections/cardSection";
import React from "react";
import { observer, useLocalStore } from "mobx-react-lite";
import { AddTestSessionStore } from "./addTestSessionStore";
import { Form } from "../../../../../components/forms/form";
import { FormInput, FormMultiSelect } from "../../../../../components/forms";
import { required } from "../../../../../components/forms/validations";
import useAsyncEffect from "use-async-effect";

const actions: Array<CardSectionActionConfigs> = [
    {
        title: "Submit",
        color: "primary",
    },
];

export const AddTestSession = observer(() => {
    const store = useLocalStore(() => new AddTestSessionStore());
    useAsyncEffect(store.loadData, []);

    return (
        <Form onValidSubmit={store.submit}>
            <CardSectionsGroup actions={actions}>
                <CardSection title="AddTestSession">
                    <FormInput
                        label="TestSession_Name"
                        value={store.name}
                        onChange={store.setName}
                        validations={[required]}
                    />
                    <FormMultiSelect
                        label="TestSession_StudentGroups"
                        placeholder="SelectItems"
                        value={store.selectedGroups}
                        options={store.groups}
                        onChange={store.setSelectedGroups}
                        validations={[required]}
                    />
                </CardSection>
            </CardSectionsGroup>
        </Form>
    );
});
