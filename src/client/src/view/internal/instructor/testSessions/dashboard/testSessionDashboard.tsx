import React from "react";
import { CardSectionsGroup } from "../../../../../components/layouts/sections/cardSectionsGroup";
import { CardSection } from "../../../../../components/layouts/sections/cardSection";
import useAsyncEffect from "use-async-effect";
import { observer, useLocalStore } from "mobx-react-lite";
import { TestSessionDashboardStore } from "./testSessionDashboardStore";
import { useParams } from "react-router-dom";
import { LabeledText } from "../../../../../components/labels/labeled";

interface IdParams {
    id: string;
}

export const TestSessionDashboard = observer(() => {
    const params = useParams<IdParams>();
    const store = useLocalStore(() => new TestSessionDashboardStore(params.id));
    useAsyncEffect(store.loadData, []);

    return (
        <CardSectionsGroup topActions={store.triggers.map(item => ({
            title: `TestSession_Trigger_${item}`,
            onClick: () => store.stateTransition(item),
        }))}>
            <CardSection title="TestSessionDetails">
                <LabeledText title="TestSessionDashboard_Name" value={store.name}/>
                <LabeledText title="TestSession_State" value={store.state}/>
            </CardSection>
        </CardSectionsGroup>
    );
});

