import { observer, useLocalStore } from "mobx-react-lite";
import { useParams } from "react-router-dom";
import { IdParams } from "../../../../../../typings/customTypings";
import { useStoreLifeCycle } from "../../../../../../core/hooks/useStoreLifeCycle";
import { Form } from "../../../../../../components/forms/form";
import { CardSectionsGroup } from "../../../../../../components/layouts/sections/cardSectionsGroup";
import { GuardedActions, GuardsApplier } from "../../../../../../core/guarding";
import React from "react";
import { QuestionViewStore } from "./questionViewStore";

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
        <Form>
            <CardSectionsGroup actions={GuardsApplier.applyGuardedArrays(store, actions)}>
                {/*<CardSection></CardSection>*/}
            </CardSectionsGroup>
        </Form>
    );
});
