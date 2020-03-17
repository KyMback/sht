import { observer, useLocalStore } from "mobx-react-lite";
import { LoginStore } from "./loginStore";
import React from "react";
import { Col, Row, Button } from "reactstrap";
import { Local } from "../../../core/localization/local";
import { emailValidation, required } from "../../../components/forms/validations";
import { FormInput } from "../../../components/forms";
import { Form } from "../../../components/forms/form";
import { routingStore } from "../../../stores/routingStore";
import { LinkButton } from "../../../components/buttons/linkButton";

export const Login = observer(() => {
    const store = useLocalStore(() => new LoginStore());

    return (
        <Row>
            <Col>
                <Form onValidSubmit={store.signIn}>
                    <FormInput
                        label="Login"
                        type="email"
                        onChange={store.setLogin}
                        value={store.login}
                        validations={[required, emailValidation]}
                    />
                    <FormInput
                        label="Password"
                        type="password"
                        onChange={store.setPassword}
                        value={store.password}
                        validations={[required]}
                    />
                    <Button color="primary">
                        <Local id="SignIn" />
                    </Button>
                    <LinkButton onClick={() => routingStore.goto("/signUp")} title="SignUp" />
                </Form>
            </Col>
        </Row>
    );
});
