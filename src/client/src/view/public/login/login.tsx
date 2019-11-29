import { useLocalStore } from "mobx-react-lite";
import { LoginStore } from "./loginStore";
import React from "react";
import { InputControl } from "../../../components/controls/inputControl";
import { Col, Row } from "reactstrap";

export const Login = () => {
    const store = useLocalStore(() => new LoginStore());

   return (
       <Row>
           <Col>
               <InputControl onChange={store.setLogin} value={store.login}/>
               <InputControl onChange={store.setPassword} value={store.password}/>
           </Col>
       </Row>
   )
};
