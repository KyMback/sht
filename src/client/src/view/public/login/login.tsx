import { observer, useLocalStore } from "mobx-react-lite";
import { LoginStore } from "./loginStore";
import React from "react";
import { Col, Row, Button } from "reactstrap";
import { Local } from "../../../core/localization/local";
import { emailValidation, required } from "../../../components/forms/validations";
import { Form } from "../../../components/forms/form";
import { routingStore } from "../../../stores/routingStore";
import { LinkButton } from "../../../components/buttons/linkButton";
import { StoreFormsFactory } from "../../../components/forms/factories/storeFormsFactory";

const FormFields = StoreFormsFactory.new<LoginStore>()
    .input("Login", "login", undefined, [required, emailValidation], { type: "email" })
    .input("Password", "password", undefined, [required], { type: "password" })
    .build();

export const Login = observer(() => {
    const store = useLocalStore(() => new LoginStore());

    return (
        <Form onValidSubmit={store.signIn}>
            <FormFields store={store} />
            <Button color="primary">
                <Local id="SignIn" />
            </Button>
            <LinkButton onClick={() => routingStore.goto("/signUp")} title="SignUp" />
        </Form>
    );
});
