import React from "react";
import { Color, IdParams } from "../../../../../typings/customTypings";
import { useParams } from "react-router-dom";
import { observer, useLocalStore } from "mobx-react-lite";
import { StudentTestSessionDashboardStore } from "./studentTestSessionDashboardStore";
import useAsyncEffect from "use-async-effect";
import {
    CardSectionActionConfigs,
    CardSectionsGroup,
} from "../../../../../components/layouts/sections/cardSectionsGroup";
import { CardSection } from "../../../../../components/layouts/sections/cardSection";
import { routingStore } from "../../../../../stores/routingStore";
import { Local } from "../../../../../core/localization/local";
import { LabeledText } from "../../../../../components/labels/labeled";
import { StartStudentTestModal } from "./stateTransition/startTest/startStudentTestModal";

const actions: Array<CardSectionActionConfigs> = [
    {
        color: "secondary" as Color,
        title: "Cancel",
        onClick: () => routingStore.goto(`/test-session`),
    },
];

export const StudentTestSessionDashboard = observer(() => {
    const params = useParams<IdParams>();
    const store = useLocalStore(() => new StudentTestSessionDashboardStore(params.id!));
    useAsyncEffect(store.loadData, []);

    const topActions: Array<CardSectionActionConfigs> = store.stateTransitions.map(item => ({
        color: "primary",
        title: `StudentTestSession_Trigger_${item}`,
        onClick: () => store.stateTransition(item),
    }));

    return (
        <>
            <CardSectionsGroup actions={actions} topActions={topActions}>
                <CardSection title={<Local id="StudentTestSession_Title" values={{ name: store.name }}/>}>
                    <LabeledText title="StudentTestSession_State" value={store.state}/>
                    <LabeledText title="StudentTestSession_Variant" value={store.variant}/>
                </CardSection>
            </CardSectionsGroup>
            {store.startStudentTestModalStore && <StartStudentTestModal store={store.startStudentTestModalStore} />}
        </>
    );
});