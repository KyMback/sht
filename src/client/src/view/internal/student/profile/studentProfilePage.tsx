import { observer, useLocalStore } from "mobx-react-lite";
import { CardSectionsGroup } from "../../../../components/layouts/sections/cardSectionsGroup";
import { CardSection } from "../../../../components/layouts/sections/cardSection";
import React from "react";
import { FormInput } from "../../../../components/forms";
import { StudentProfileStore } from "./studentProfileStore";
import { useStoreLifeCycle } from "../../../../core/hooks/useStoreLifeCycle";
import { Row } from "reactstrap";
import { DefaultCol } from "../../../../components/layouts/defaultCol";
import { ViewContextWrapper } from "../../../../components/forms/view/core/viewContextWrapper";
import { ViewModeType } from "../../../../components/forms/view/core/viewContextStore";
import { StudentProfileAdditionalInfo } from "./studentProfileAdditionalInfo";

export const StudentProfilePage = observer(() => {
    const store = useLocalStore(() => new StudentProfileStore());
    useStoreLifeCycle(store);

    return (
        <CardSectionsGroup title="Profile">
            <ViewContextWrapper mode={ViewModeType.View}>
                <CardSection title="AccountInfo">
                    <Row>
                        <DefaultCol>
                            <FormInput value={store.email} label="Email" />
                        </DefaultCol>
                    </Row>
                </CardSection>
            </ViewContextWrapper>
            <StudentProfileAdditionalInfo store={store} />
        </CardSectionsGroup>
    );
});
