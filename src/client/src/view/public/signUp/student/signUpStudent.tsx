import { observer, useLocalStore } from "mobx-react-lite";
import { SignUpStudentStore } from "./signUpStudentStore";
import { Form } from "../../../../components/forms/form";
import { CardSectionBottomActions } from "../../../../components/layouts/sections/cardSectionBottomActions";
import React from "react";
import { CardSectionActionProps } from "../../../../components/layouts/sections/cardSection";
import { routingStore } from "../../../../stores/routingStore";
import { StoreFormsFactory } from "../../../../components/forms/factories/storeFormsFactory";
import { emailValidation, required } from "../../../../components/forms/validations";
import { SubSection } from "../../../../components/layouts/sections/subSection";
import { Col, Row } from "reactstrap";

const actions: Array<CardSectionActionProps> = [
    {
        color: "secondary",
        text: "Cancel",
        onClick: () => routingStore.gotoBase(),
    },
    {
        color: "primary",
        text: "SignUp",
    },
];

const AccountInfo = StoreFormsFactory.new<SignUpStudentStore>()
    .input("Email", "email", undefined, [required, emailValidation], { type: "email" })
    .input("Password", "password", undefined, store => [required, store.repeatPasswordValidation], {
        type: "password",
    })
    .input("RepeatPassword", "repeatPassword", undefined, store => [required, store.repeatPasswordValidation], {
        type: "password",
    })
    .build();

const AdditionalInfo = StoreFormsFactory.new<SignUpStudentStore>()
    .input("FirstName", "firstName", undefined, [required])
    .input("LastName", "lastName", undefined, [required])
    .input("Group", "group", undefined, [required])
    .build();

export const SignUpStudent = observer(() => {
    const store = useLocalStore(() => new SignUpStudentStore());
    return (
        <Form onValidSubmit={store.signUp}>
            <Row>
                <Col md={6}>
                    <SubSection title="AccountInfo">
                        <AccountInfo store={store} />
                    </SubSection>
                </Col>
                <Col>
                    <SubSection title="AdditionalInfo">
                        <AdditionalInfo store={store} />
                    </SubSection>
                </Col>
            </Row>
            <CardSectionBottomActions actions={actions} />
        </Form>
    );
});
