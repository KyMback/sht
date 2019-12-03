import React from "react";
import { CardSection } from "../../../components/layouts/sections/cardSection";
import { observer, useLocalStore } from "mobx-react-lite";
import { SignUpStudentStore } from "./signUpStudentStore";
import { Form } from "../../../components/forms/form";
import { FormInput } from "../../../components/forms";
import { emailValidation, required } from "../../../components/forms/validations";
import { CardSectionActionConfigs, CardSectionsGroup } from "../../../components/layouts/sections/cardSectionsGroup";

const actions: Array<CardSectionActionConfigs> = [
    {
        title: "Submit",
        color: "primary",
    },
];

export const SignUpStudent = observer(() => {
    const store = useLocalStore(() => new SignUpStudentStore());

    return (
        <Form onValidSubmit={store.signUp}>
            <CardSectionsGroup actions={actions}>
                <CardSection>
                    <FormInput
                        label="Email"
                        type="email"
                        value={store.email}
                        onChange={store.setEmail}
                        validations={[required, emailValidation]}
                    />
                    <FormInput
                        label="FirstName"
                        value={store.firstName}
                        onChange={store.setFirstName}
                        validations={[required]}
                    />
                    <FormInput
                        label="LastName"
                        value={store.lastName}
                        onChange={store.setLastName}
                        validations={[required]}
                    />
                    <FormInput
                        label="Group"
                        value={store.group}
                        onChange={store.setGroup}
                        validations={[required]}
                    />
                    <FormInput
                        label="Password"
                        type="password"
                        value={store.password}
                        onChange={store.setPassword}
                        validations={[required]}
                    />
                    <FormInput
                        label="RepeatPassword"
                        type="password"
                        value={store.repeatPassword}
                        onChange={store.setRepeatPassword}
                        validations={[required, store.repeatPasswordValidation]}
                    />
                </CardSection>
            </CardSectionsGroup>
        </Form>
    );
});
