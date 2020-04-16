import React from "react";
import { CardSection } from "../../../components/layouts/sections/cardSection";
import { observer, useLocalStore } from "mobx-react-lite";
import { SignUpStudentStore } from "./signUpStudentStore";
import { Form } from "../../../components/forms/form";
import { emailValidation, required } from "../../../components/forms/validations";
import { CardSectionActionConfigs, CardSectionsGroup } from "../../../components/layouts/sections/cardSectionsGroup";
import { StoreFormsFactory } from "../../../components/forms/factories/storeFormsFactory";

const actions: Array<CardSectionActionConfigs> = [
    {
        title: "Submit",
        color: "primary",
    },
];

const FormFields = StoreFormsFactory.new<SignUpStudentStore>()
    .input("Email", "email", undefined, [required, emailValidation], { type: "email" })
    .input("FirstName", "firstName", undefined, [required])
    .input("LastName", "lastName", undefined, [required])
    .input("Group", "group", undefined, [required])
    .input("Password", "password", undefined, store => [required, store.repeatPasswordValidation], { type: "password" })
    .input("RepeatPassword", "repeatPassword", undefined, store => [required, store.repeatPasswordValidation], {
        type: "password",
    })
    .build();

export const SignUpStudent = observer(() => {
    const store = useLocalStore(() => new SignUpStudentStore());

    return (
        <Form onValidSubmit={store.signUp}>
            <CardSectionsGroup actions={actions}>
                <CardSection>
                    <FormFields store={store} />
                </CardSection>
            </CardSectionsGroup>
        </Form>
    );
});
