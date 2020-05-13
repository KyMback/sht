import React from "react";
import { IdParams } from "../../../../../typings/customTypings";
import { useParams } from "react-router-dom";
import { observer, useLocalStore } from "mobx-react-lite";
import { StudentTestSessionDashboardStore } from "./studentTestSessionDashboardStore";
import useAsyncEffect from "use-async-effect";
import { CardSectionsGroup } from "../../../../../components/layouts/sections/cardSectionsGroup";
import { CardSection } from "../../../../../components/layouts/sections/cardSection";
import { routingStore } from "../../../../../stores/routingStore";
import { Local } from "../../../../../core/localization/local";
import { LabeledText } from "../../../../../components/labels/labeled";
import { GenericButtonProps } from "../../../../../components/buttons/genericButton/genericButton";
import { GuardedActions, GuardsApplier } from "../../../../../core/guarding";

const actions: Array<GenericButtonProps> = [
    {
        color: "secondary",
        text: "Cancel",
        onClick: () => routingStore.goto(`/test-session`),
    },
];

export const StudentTestSessionDashboard = observer(() => {
    const params = useParams<IdParams>();
    const store = useLocalStore(() => new StudentTestSessionDashboardStore(params.id!));
    useAsyncEffect(store.loadData, []);

    return (
        <CardSectionsGroup
            title={<Local id="StudentTestSession_Title" values={{ name: store.name }} />}
            actions={actions}
            topActions={GuardsApplier.applyGuardedArrays(store, guardedActions)}
        >
            <CardSection>
                <LabeledText title="StudentTestSession_State" value={store.state} />
                <LabeledText title="StudentTestSession_Variant" value={store.testVariant} />
            </CardSection>
        </CardSectionsGroup>
    );
});

const guardedActions: GuardedActions<StudentTestSessionDashboardStore> = [
    {
        guard: store => store.isQuestionsAvailable,
        data: store => [
            {
                text: "StudentTestSession_OpenQuestions",
                onClick: () => routingStore.goto(`/test-session/${store.id}/questions`),
                color: "primary",
            },
        ],
    },
    {
        data: store =>
            store.stateTransitions.map(item => ({
                color: "primary",
                text: `StudentTestSession_Trigger_${item}`,
                onClick: () => store.stateTransition(item),
            })),
    },
];
