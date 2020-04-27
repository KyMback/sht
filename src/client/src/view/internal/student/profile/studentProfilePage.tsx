import { observer, useLocalStore } from "mobx-react-lite";
import { CardSectionsGroup } from "../../../../components/layouts/sections/cardSectionsGroup";
import { CardSection } from "../../../../components/layouts/sections/cardSection";
import React from "react";
import { ViewContextProps, withViewContext } from "../../../../components/forms/view/core/withViewContext";
import { PropsWithStore } from "../../../../typings/customTypings";
import { FormInput } from "../../../../components/forms";
import { StudentProfileStore } from "./studentProfileStore";
import { useStoreLifeCycle } from "../../../../core/hooks/useStoreLifeCycle";
import { Row } from "reactstrap";
import { DefaultCol } from "../../../../components/layouts/defaultCol";

export const StudentProfilePage = observer(() => {
    const store = useLocalStore(() => new StudentProfileStore());
    useStoreLifeCycle(store);

    return (
        <CardSectionsGroup title="Profile">
            <StudentAccountDetails store={store} mode={store.viewModeType} />
            <StudentProfileDetails store={store} mode={store.viewModeType} />
        </CardSectionsGroup>
    );
});

const StudentAccountDetails = withViewContext(
    observer(({ store }: PropsWithStore<StudentProfileStore> & ViewContextProps) => {
        return (
            <CardSection title="AccountInfo">
                <Row>
                    <DefaultCol>
                        <FormInput value={store.email} label="Email" />
                    </DefaultCol>
                </Row>
            </CardSection>
        );
    }),
);

const StudentProfileDetails = withViewContext(
    observer(({ store }: PropsWithStore<StudentProfileStore> & ViewContextProps) => {
        return (
            <CardSection title="AdditionalInfo">
                <Row>
                    <DefaultCol>
                        <FormInput value={store.firstName} label="FirstName" />
                    </DefaultCol>
                </Row>
                <Row>
                    <DefaultCol>
                        <FormInput value={store.lastName} label="LastName" />
                    </DefaultCol>
                </Row>
                <Row>
                    <DefaultCol>
                        <FormInput value={store.group} label="Group" />
                    </DefaultCol>
                </Row>
            </CardSection>
        );
    }),
);
