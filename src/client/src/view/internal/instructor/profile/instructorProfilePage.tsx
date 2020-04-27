import { observer, useLocalStore } from "mobx-react-lite";
import React from "react";
import { CardSectionsGroup } from "../../../../components/layouts/sections/cardSectionsGroup";
import { CardSection } from "../../../../components/layouts/sections/cardSection";
import { ViewContextProps, withViewContext } from "../../../../components/forms/view/core/withViewContext";
import { PropsWithStore } from "../../../../typings/customTypings";
import { FormInput } from "../../../../components/forms";
import { InstructorProfileStore } from "./instructorProfileStore";
import { useStoreLifeCycle } from "../../../../core/hooks/useStoreLifeCycle";

export const InstructorProfilePage = observer(() => {
    const store = useLocalStore(() => new InstructorProfileStore());
    useStoreLifeCycle(store);

    return (
        <CardSectionsGroup title="Profile">
            <CardSection>
                <InstructorProfileDetails store={store} mode={store.viewModeType} />
            </CardSection>
        </CardSectionsGroup>
    );
});

const InstructorProfileDetails = withViewContext(
    observer(({ store }: PropsWithStore<InstructorProfileStore> & ViewContextProps) => {
        return <FormInput value={store.email} label="Email" />;
    }),
);
