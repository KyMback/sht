import { CardSectionsGroup } from "../../../../components/layouts/sections/cardSectionsGroup";
import { CardSection } from "../../../../components/layouts/sections/cardSection";
import React from "react";
import { observer, useLocalStore } from "mobx-react-lite";
import { AddTestSessionStore } from "./addTestSessionStore";
import { Form } from "../../../../components/forms/form";
import { FormInput } from "../../../../components/forms";
import { required } from "../../../../components/forms/validations";

const actions = [
    {
        title: "Submit",
    },
];

export const AddTestSession = observer(() => {
    const store = useLocalStore(() => new AddTestSessionStore());

    return (
        <Form onValidSubmit={store.submit}>
            <CardSectionsGroup actions={actions}>
                <CardSection title="AddTestSession">
                    <FormInput
                        label="TestSessionName"
                        value={store.name}
                        onChange={store.setName}
                        validations={[required]}
                    />
                </CardSection>
            </CardSectionsGroup>
        </Form>
    );
});
