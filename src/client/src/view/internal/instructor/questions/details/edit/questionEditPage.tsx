import { useParams } from "react-router-dom";
import { IdParams } from "../../../../../../typings/customTypings";
import { observer, useLocalStore } from "mobx-react-lite";
import { useStoreLifeCycle } from "../../../../../../core/hooks/useStoreLifeCycle";
import { Form } from "../../../../../../components/forms/form";
import { CardSectionsGroup } from "../../../../../../components/layouts/sections/cardSectionsGroup";
import React from "react";
import { GuardedActions, GuardsApplier } from "../../../../../../core/guarding";
import { QuestionEditStore } from "./questionEditStore";

const actions: GuardedActions<QuestionEditStore> = [
    {
        data: store => [
            {
                color: "secondary",
                text: "Cancel",
                onClick: store.cancel,
            },
        ],
    },
    {
        data: _ => [
            {
                color: "primary",
                text: "Save",
            },
        ],
    },
];

export const QuestionEditPage = observer(() => {
    const { id } = useParams<IdParams>();
    const store = useLocalStore(() => new QuestionEditStore(id));
    useStoreLifeCycle(store);

    return (
        <Form>
            <CardSectionsGroup actions={GuardsApplier.applyGuardedArrays(store, actions)}>
                {/*<CardSection></CardSection>*/}
            </CardSectionsGroup>
        </Form>
    );
});
