import { Form } from "../../../../../../components/forms/form";
import { CardSectionsGroup } from "../../../../../../components/layouts/sections/cardSectionsGroup";
import { CardSection } from "../../../../../../components/layouts/sections/cardSection";
import { Local } from "../../../../../../core/localization/local";
import React from "react";
import { IdParams } from "../../../../../../typings/customTypings";
import { useParams } from "react-router-dom";
import { routingStore } from "../../../../../../stores/routingStore";
import { observer } from "mobx-react-lite";
import { DisableCopyPasteWrapper } from "../../../../../../components/common/disableCopyPasteWrapper";
import { GenericButtonProps } from "../../../../../../components/buttons/genericButton/genericButton";
import { StudentQuestionsContextStore, useStudentQuestionsContext } from "./studentQuestionsContextStore";
import { GuardedActions, GuardsApplier } from "../../../../../../core/guarding";
import { QuestionSpecificComponent } from "./questionSpecificComponent";

const actions: Array<GenericButtonProps> = [
    {
        color: "primary",
        text: "Submit",
    },
];

const topActions: GuardedActions<StudentQuestionsContextStore> = [
    {
        data: store => [
            {
                color: "primary",
                text: "Back",
                onClick: () => routingStore.goto(`/test-session/${store.sessionId}/questions`),
            },
        ],
    },
];

export const BaseQuestionPage = observer(() => {
    const params = useParams<IdParams>();
    const context = useStudentQuestionsContext();
    const store = context.getOrCreateStore(params.id!);

    return (
        <Form onValidSubmit={store.submit}>
            <CardSectionsGroup
                title={<Local id="TestVariantTemplate" values={{ variant: context.variant }} />}
                topActions={GuardsApplier.applyGuardedArrays(context, topActions)}
                actions={actions}
            >
                <CardSection title={<Local id="Question_TitleTemplate" values={{ number: store.number }} />}>
                    <DisableCopyPasteWrapper>
                        <QuestionSpecificComponent store={store} />
                    </DisableCopyPasteWrapper>
                </CardSection>
            </CardSectionsGroup>
        </Form>
    );
});
