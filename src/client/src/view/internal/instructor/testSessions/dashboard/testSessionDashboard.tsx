import React from "react";
import {
    CardSectionActionConfigs,
    CardSectionsGroup,
} from "../../../../../components/layouts/sections/cardSectionsGroup";
import { CardSection } from "../../../../../components/layouts/sections/cardSection";
import useAsyncEffect from "use-async-effect";
import { observer, useLocalStore } from "mobx-react-lite";
import { TestSessionDashboardStore } from "./testSessionDashboardStore";
import { useParams } from "react-router-dom";
import { LabeledText } from "../../../../../components/labels/labeled";
import { Color, IdParams } from "../../../../../typings/customTypings";
import { routingStore } from "../../../../../stores/routingStore";

export const TestSessionDashboard = observer(() => {
    const params = useParams<IdParams>();
    const store = useLocalStore(() => new TestSessionDashboardStore(params.id!));
    useAsyncEffect(store.loadData, []);

    const actions: Array<CardSectionActionConfigs> = [
        {
            color: "primary" as Color,
            title: `Edit`,
            onClick: () => routingStore.goto(`/test-session/edit/${store.id}`),
        },
    ].concat(store.triggers.map(item => ({
        color: "primary",
        title: `TestSession_Trigger_${item}`,
        onClick: () => store.stateTransition(item),
    })));

    return (
        <CardSectionsGroup topActions={actions}>
            <CardSection title="TestSession_Details">
                <LabeledText title="TestSessionDashboard_Name" value={store.name}/>
                <LabeledText title="TestSession_State" value={store.state}/>
            </CardSection>
        </CardSectionsGroup>
    );
});

