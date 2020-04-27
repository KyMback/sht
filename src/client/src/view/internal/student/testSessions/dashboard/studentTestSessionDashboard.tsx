import React from "react";
import { Color, IdParams } from "../../../../../typings/customTypings";
import { useParams } from "react-router-dom";
import { observer, useLocalStore } from "mobx-react-lite";
import { StudentTestSessionDashboardStore } from "./studentTestSessionDashboardStore";
import useAsyncEffect from "use-async-effect";
import { CardSectionsGroup } from "../../../../../components/layouts/sections/cardSectionsGroup";
import { CardSection } from "../../../../../components/layouts/sections/cardSection";
import { routingStore } from "../../../../../stores/routingStore";
import { Local } from "../../../../../core/localization/local";
import { LabeledText } from "../../../../../components/labels/labeled";
import { StartStudentTestModal } from "./stateTransition/startTest/startStudentTestModal";
import { GenericButtonProps } from "../../../../../components/buttons/genericButton/genericButton";

const actions: Array<GenericButtonProps> = [
    {
        color: "secondary" as Color,
        text: "Cancel",
        onClick: () => routingStore.goto(`/test-session`),
    },
];

export const StudentTestSessionDashboard = observer(() => {
    const params = useParams<IdParams>();
    const store = useLocalStore(() => new StudentTestSessionDashboardStore(params.id!));
    useAsyncEffect(store.loadData, []);

    const topActions: Array<GenericButtonProps> = store.isQuestionsAvailable
        ? [
              {
                  text: "StudentTestSession_OpenQuestions",
                  onClick: () => routingStore.goto(`/test-session/${params.id}/questions`),
                  color: "primary",
              },
          ]
        : [];

    const stateTransitionOptions: Array<GenericButtonProps> = store.stateTransitions.map(item => ({
        color: "primary",
        text: `StudentTestSession_Trigger_${item}`,
        onClick: () => store.stateTransition(item),
    }));

    return (
        <>
            <CardSectionsGroup
                title={<Local id="StudentTestSession_Title" values={{ name: store.name }} />}
                actions={actions}
                topActions={topActions.concat(stateTransitionOptions)}
            >
                <CardSection>
                    <LabeledText title="StudentTestSession_State" value={store.state} />
                    <LabeledText title="StudentTestSession_Variant" value={store.testVariant} />
                </CardSection>
            </CardSectionsGroup>
            {store.startStudentTestModalStore && <StartStudentTestModal store={store.startStudentTestModalStore} />}
        </>
    );
});
