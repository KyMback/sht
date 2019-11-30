import { observer, useLocalStore } from "mobx-react-lite";
import { LoginStore } from "./loginStore";
import React from "react";
import { InputControl } from "../../../components/controls/inputControl";
import { Col, Row, Button } from "reactstrap";
import { Local } from "../../../core/localization/local";

export const Login = observer(() => {
    const store = useLocalStore(() => new LoginStore());

    return (
        <Row>
            <Col>
                <InputControl onChange={store.setLogin} value={store.login}/>
                <InputControl onChange={store.setPassword} value={store.password}/>
                <Button onClick={store.signIn}><Local id="SignIn"/></Button>
            </Col>
        </Row>
    );
});
