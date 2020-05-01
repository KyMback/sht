import { observer, useLocalStore } from "mobx-react-lite";
import { useParams } from "react-router-dom";
import { IdParams, PropsWithStore } from "../../../../../../typings/customTypings";
import { useStoreLifeCycle } from "../../../../../../core/hooks/useStoreLifeCycle";
import { CardSectionsGroup } from "../../../../../../components/layouts/sections/cardSectionsGroup";
import { GuardedActions, GuardsApplier } from "../../../../../../core/guarding";
import React from "react";
import { QuestionViewStore } from "./questionViewStore";
import { Row } from "reactstrap";
import { CardSection } from "../../../../../../components/layouts/sections/cardSection";
import { DefaultCol } from "../../../../../../components/layouts/defaultCol";
import { LabeledEnum, LabeledText } from "../../../../../../components/labels/labeled";
import { QuestionType } from "../../../../../../typings/dataContracts";
import { FreeTextQuestionViewSection } from "./sections/freeText/freeTextQuestionViewSection";

const actions: GuardedActions<QuestionViewStore> = [
    {
        data: store => [
            {
                text: "Cancel",
                color: "secondary",
                onClick: store.cancel,
            },
        ],
    },
    {
        guard: store => store.canEdt,
        data: store => [
            {
                text: "Edit",
                color: "primary",
                onClick: store.edit,
            },
        ],
    },
];

export const QuestionViewPage = observer(() => {
    const { id } = useParams<IdParams>();
    const store = useLocalStore(() => new QuestionViewStore(id!));
    useStoreLifeCycle(store);

    return (
        <CardSectionsGroup title="Question" topActions={GuardsApplier.applyGuardedArrays(store, actions)}>
            <CardSection>
                <Row>
                    <DefaultCol>
                        <LabeledText title="Name" value={store.name} />
                    </DefaultCol>
                </Row>
                <Row>
                    <DefaultCol>
                        <LabeledEnum title="Type" enumObject={QuestionType} value={store.type} />
                    </DefaultCol>
                </Row>
            </CardSection>
            <QuestionSpecialSection store={store} />
        </CardSectionsGroup>
    );
});

const QuestionSpecialSection = observer(({ store }: PropsWithStore<QuestionViewStore>) => {
    switch (store.type) {
        case QuestionType.FreeText:
            return <FreeTextQuestionViewSection store={store.freeTextQuestionStore!} />;
    }

    return null;
});
