import { useParams } from "react-router-dom";
import { IdParams, PropsWithStore } from "../../../../../../typings/customTypings";
import { observer, useLocalStore } from "mobx-react-lite";
import { useStoreLifeCycle } from "../../../../../../core/hooks/useStoreLifeCycle";
import { Form } from "../../../../../../components/forms/form";
import { CardSectionsGroup } from "../../../../../../components/layouts/sections/cardSectionsGroup";
import React from "react";
import { GuardedActions, GuardsApplier } from "../../../../../../core/guarding";
import { QuestionEditStore } from "./questionEditStore";
import { CardSection } from "../../../../../../components/layouts/sections/cardSection";
import { FreeTextQuestionEditSection } from "./sections/freeText/freeTextQuestionEditSection";
import { maxMediumLength, required } from "../../../../../../components/forms/validations";
import { QuestionType } from "../../../../../../typings/dataContracts";
import { Row } from "reactstrap";
import { DefaultCol } from "../../../../../../components/layouts/defaultCol";
import { FormEnumSelect, FormInput } from "../../../../../../components/forms";
import { QuestionWithChoiceEditSection } from "./sections/withChoice/questionWithChoiceEditSection";

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
        <Form onValidSubmit={store.save}>
            <CardSectionsGroup title="Question" topActions={GuardsApplier.applyGuardedArrays(store, actions)}>
                <CardSection>
                    <Row>
                        <DefaultCol>
                            <FormInput
                                label="Name"
                                value={store.name}
                                onChange={store.setName}
                                validations={[required, maxMediumLength]}
                            />
                        </DefaultCol>
                    </Row>
                    <Row>
                        <DefaultCol>
                            <FormEnumSelect
                                label="Type"
                                enumObject={QuestionType}
                                value={store.type}
                                onChange={store.setType}
                                validations={[required]}
                            />
                        </DefaultCol>
                    </Row>
                </CardSection>
                <QuestionSpecialSection store={store} />
            </CardSectionsGroup>
        </Form>
    );
});

const QuestionSpecialSection = observer(({ store }: PropsWithStore<QuestionEditStore>) => {
    switch (store.type) {
        case QuestionType.FreeText:
            return <FreeTextQuestionEditSection store={store.freeTextStore!} />;
        case QuestionType.QuestionWithChoice:
            return <QuestionWithChoiceEditSection store={store.choiceQuestionStore!} />;
        default:
            return null;
    }
});
