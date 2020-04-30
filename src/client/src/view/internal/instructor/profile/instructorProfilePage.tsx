import { observer, useLocalStore } from "mobx-react-lite";
import React from "react";
import { CardSectionsGroup } from "../../../../components/layouts/sections/cardSectionsGroup";
import { CardSection } from "../../../../components/layouts/sections/cardSection";
import { FormInput } from "../../../../components/forms";
import { InstructorProfileStore } from "./instructorProfileStore";
import { useStoreLifeCycle } from "../../../../core/hooks/useStoreLifeCycle";
import { ViewContextWrapper } from "../../../../components/forms/view/core/viewContextWrapper";

export const InstructorProfilePage = observer(() => {
    const store = useLocalStore(() => new InstructorProfileStore());
    useStoreLifeCycle(store);

    return (
        <CardSectionsGroup title="Profile">
            <CardSection>
                <ViewContextWrapper mode={store.viewModeType}>
                    <FormInput value={store.email} label="Email" />
                </ViewContextWrapper>
            </CardSection>
        </CardSectionsGroup>
    );
});
