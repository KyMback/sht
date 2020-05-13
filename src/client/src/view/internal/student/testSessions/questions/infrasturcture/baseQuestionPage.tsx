import { Form } from "../../../../../../components/forms/form";
import { CardSectionsGroup } from "../../../../../../components/layouts/sections/cardSectionsGroup";
import { CardSection } from "../../../../../../components/layouts/sections/cardSection";
import { Local } from "../../../../../../core/localization/local";
import React, { useContext, useMemo } from "react";
import { IdParams, PropsWithStore } from "../../../../../../typings/customTypings";
import { useParams } from "react-router-dom";
import { StudentQuestionsContext } from "../studentQuestionsModule";
import { BaseQuestionStore } from "./baseQuestionStore";
import { QuestionType } from "../../../../../../typings/dataContracts";
import { FreeTextQuestion } from "../freeTextQuestion/freeTextQuestion";
import { routingStore } from "../../../../../../stores/routingStore";
import { observer } from "mobx-react-lite";
import { FreeTextQuestionStore } from "../freeTextQuestion/freeTextQuestionStore";
import { DisableCopyPasteWrapper } from "../../../../../../components/common/disableCopyPasteWrapper";
import { GenericButtonProps } from "../../../../../../components/buttons/genericButton/genericButton";

const actions: Array<GenericButtonProps> = [
    {
        color: "primary",
        text: "Submit",
    },
];

export const BaseQuestionPage = observer(() => {
    const params = useParams<IdParams>();
    const context = useContext(StudentQuestionsContext)!;
    const store = context.getOrCreateStore(params.id!);

    const topActions: Array<GenericButtonProps> = [
        {
            color: "primary",
            text: "Back",
            onClick: () => routingStore.goto(`/test-session/${context.sessionId}/questions`),
        },
    ];

    return (
        <Form onValidSubmit={store.submit}>
            <CardSectionsGroup
                title={<Local id="TestVariantTemplate" values={{ variant: context.variant }} />}
                topActions={topActions}
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

const QuestionSpecificComponent = observer(({ store }: PropsWithStore<BaseQuestionStore>) => {
    switch (store.type) {
        case QuestionType.FreeText:
            return <FreeTextQuestion store={store as FreeTextQuestionStore} />;
        default:
            return <Local id="NotImplementedYet" />;
    }
});
