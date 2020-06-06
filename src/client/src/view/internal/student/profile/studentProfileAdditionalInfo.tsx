import { observer } from "mobx-react-lite";
import { PropsWithStore } from "../../../../typings/customTypings";
import { StudentProfileStore } from "./studentProfileStore";
import { Form } from "../../../../components/forms/form";
import { ViewContextWrapper } from "../../../../components/forms/view/core/viewContextWrapper";
import { CardSection } from "../../../../components/layouts/sections/cardSection";
import { icons } from "../../../../components/icons/icon";
import { Row } from "reactstrap";
import { DefaultCol } from "../../../../components/layouts/defaultCol";
import { FormInput } from "../../../../components/forms";
import { maxSmallLength, required } from "../../../../components/forms/validations";
import React from "react";
import { GuardedActions, GuardsApplier } from "../../../../core/guarding";
import { ViewModeType } from "../../../../components/forms/view/core/viewContextStore";

const bottomActions: GuardedActions<StudentProfileStore> = [
    {
        guard: store => store.viewModeType === ViewModeType.Edit,
        data: _ => [
            {
                text: "Save",
                color: "primary",
            },
        ],
    },
];

const actions: GuardedActions<StudentProfileStore> = [
    {
        data: store => [
            {
                color: "primary",
                icon: icons.edit,
                onClick: store.toggleViewMode,
            },
        ],
    },
];

export const StudentProfileAdditionalInfo = observer(({ store }: PropsWithStore<StudentProfileStore>) => {
    return (
        <Form onValidSubmit={store.update}>
            <ViewContextWrapper mode={store.viewModeType}>
                <CardSection
                    title="AdditionalInfo"
                    actions={GuardsApplier.applyGuardedArrays(store, actions)}
                    bottomActions={GuardsApplier.applyGuardedArrays(store, bottomActions)}
                >
                    <Row>
                        <DefaultCol>
                            <FormInput
                                value={store.firstName}
                                onChange={store.setFirstName}
                                label="FirstName"
                                validations={[required, maxSmallLength]}
                            />
                        </DefaultCol>
                    </Row>
                    <Row>
                        <DefaultCol>
                            <FormInput
                                value={store.lastName}
                                onChange={store.setLastName}
                                label="LastName"
                                validations={[required, maxSmallLength]}
                            />
                        </DefaultCol>
                    </Row>
                    <Row>
                        <DefaultCol>
                            <FormInput
                                value={store.group}
                                onChange={store.setGroup}
                                label="Group"
                                validations={[required, maxSmallLength]}
                            />
                        </DefaultCol>
                    </Row>
                </CardSection>
            </ViewContextWrapper>
        </Form>
    );
});
