import React from "react";
import { CardSectionsGroup } from "../../../../../components/layouts/sections/cardSectionsGroup";
import { CardSection } from "../../../../../components/layouts/sections/cardSection";
import useAsyncEffect from "use-async-effect";
import { observer, useLocalStore } from "mobx-react-lite";
import { TestSessionDashboardStore } from "./testSessionDashboardStore";
import { useParams } from "react-router-dom";
import { LabeledText } from "../../../../../components/labels/labeled";
import { Color, IdParams } from "../../../../../typings/customTypings";
import { routingStore } from "../../../../../stores/routingStore";
import { GuardedActions, GuardsApplier } from "../../../../../core/guarding";
import { localizeTestSessionState } from "../../../../../services/testSessions/testSessionUtils";

export const TestSessionDashboard = observer(() => {
    const params = useParams<IdParams>();
    const store = useLocalStore(() => new TestSessionDashboardStore(params.id!));
    useAsyncEffect(store.loadData, []);

    return (
        <CardSectionsGroup topActions={GuardsApplier.applyGuardedArrays(store, guardedActions)}>
            <CardSection title="TestSession_Details">
                <LabeledText title="TestSessionDashboard_Name" value={store.name} />
                <LabeledText title="TestSession_State" value={localizeTestSessionState(store.state)} />
            </CardSection>
        </CardSectionsGroup>
    );
});

const guardedActions: GuardedActions<TestSessionDashboardStore> = [
    {
        data: _ => [
            {
                color: "secondary" as Color,
                text: "Cancel",
                onClick: () => routingStore.goto(`/test-session`),
            },
        ],
    },
    {
        guard: store => store.canEdit,
        data: store => [
            {
                color: "primary" as Color,
                text: "Edit",
                onClick: () => routingStore.goto(`/test-session/edit/${store.id}`),
            },
        ],
    },
    {
        data: store =>
            store.triggers.map(item => ({
                color: "primary",
                text: `TestSession_Trigger_${item}`,
                onClick: () => store.stateTransition(item),
            })),
    },
];
