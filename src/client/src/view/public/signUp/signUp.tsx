import React from "react";
import { CardSection } from "../../../components/layouts/sections/cardSection";
import { observer, useLocalStore } from "mobx-react-lite";
import { SignUpStore } from "./signUpStore";
import { Form } from "../../../components/forms/form";
import { FormInput } from "../../../components/forms";
import { required } from "../../../components/forms/validations";
import { CardSectionActionConfigs, CardSectionsGroup } from "../../../components/layouts/sections/cardSectionsGroup";

const actions: Array<CardSectionActionConfigs> = [
    {
        title: "Submit",
    },
];

export const SignUp = observer(() => {
    const store = useLocalStore(() => new SignUpStore());

    return (
        <Form onValidSubmit={store.signUp}>
            <CardSectionsGroup actions={actions}>
                <CardSection>
                    <FormInput
                        label="Login"
                        value={store.login}
                        onChange={store.setLogin}
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
