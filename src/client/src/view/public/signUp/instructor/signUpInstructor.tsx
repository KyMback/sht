import { observer, useLocalStore } from "mobx-react-lite";
import { useStoreLifeCycle } from "../../../../core/hooks/useStoreLifeCycle";
import { Form } from "../../../../components/forms/form";
import { Row } from "reactstrap";
import { SubSection } from "../../../../components/layouts/sections/subSection";
import { CardSectionBottomActions } from "../../../../components/layouts/sections/cardSectionBottomActions";
import React from "react";
import { CardSectionActionProps } from "../../../../components/layouts/sections/cardSection";
import { routingStore } from "../../../../stores/routingStore";
import { StoreFormsFactory } from "../../../../components/forms/factories/storeFormsFactory";
import { emailValidation, required } from "../../../../components/forms/validations";
import { DefaultCol } from "../../../../components/layouts/defaultCol";
import { SignUpInstructorStore } from "./signUpInstructorStore";

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

const AccountInfo = StoreFormsFactory.new<SignUpInstructorStore>()
    .input("Email", "email", undefined, [required, emailValidation], { type: "email" })
    .input("Password", "password", undefined, store => store.passwordValidations, {
        type: "password",
    })
    .input("RepeatPassword", "repeatPassword", undefined, store => [required, store.repeatPasswordValidation], {
        type: "password",
    })
    .build();

export const SignUpInstructor = observer(() => {
    const store = useLocalStore(() => new SignUpInstructorStore());
    useStoreLifeCycle(store);

    return (
        <Form onValidSubmit={store.signUp}>
            <Row>
                <DefaultCol>
                    <SubSection title="AccountInfo">
                        <AccountInfo store={store} />
                    </SubSection>
                </DefaultCol>
            </Row>
            <CardSectionBottomActions actions={actions} />
        </Form>
    );
});
