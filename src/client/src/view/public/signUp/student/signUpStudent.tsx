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
import { Row } from "reactstrap";
import { useStoreLifeCycle } from "../../../../core/hooks/useStoreLifeCycle";
import { DefaultCol } from "../../../../components/layouts/defaultCol";

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
    .input("Password", "password", undefined, store => store.passwordValidations, {
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
    useStoreLifeCycle(store);

    return (
        <Form onValidSubmit={store.signUp}>
            <Row>
                <DefaultCol>
                    <SubSection title="AccountInfo">
                        <AccountInfo store={store} />
                    </SubSection>
                </DefaultCol>
                <DefaultCol>
                    <SubSection title="AdditionalInfo">
                        <AdditionalInfo store={store} />
                    </SubSection>
                </DefaultCol>
            </Row>
            <CardSectionBottomActions actions={actions} />
        </Form>
    );
});
