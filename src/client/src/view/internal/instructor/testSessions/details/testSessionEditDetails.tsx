import { CardSectionsGroup } from "../../../../../components/layouts/sections/cardSectionsGroup";
import { CardSection } from "../../../../../components/layouts/sections/cardSection";
import React from "react";
import { observer, useLocalStore } from "mobx-react-lite";
import { TestSessionDetailsEditStore } from "./testSessionDetailsEditStore";
import { Form } from "../../../../../components/forms/form";
import { FormInput, FormMultiSelect } from "../../../../../components/forms";
import { required } from "../../../../../components/forms/validations";
import useAsyncEffect from "use-async-effect";
import { ListGroup, Row } from "reactstrap";
import { icons } from "../../../../../components/icons/icon";
import { TestSessionVariant } from "./variants/testSessionVariant";
import { useParams } from "react-router-dom";
import { IdParams } from "../../../../../typings/customTypings";
import { DefaultCol } from "../../../../../components/layouts/defaultCol";
import { GuardedActions, GuardsApplier } from "../../../../../core/guarding";
import { AssessmentSection } from "./assessment/assessmentSection";

export const TestSessionEditDetails = observer(() => {
    const params = useParams<IdParams>();
    const store = useLocalStore(() => new TestSessionDetailsEditStore(params.id));
    useAsyncEffect(store.loadData, []);

    return (
        <Form onValidSubmit={store.save}>
            <CardSectionsGroup actions={GuardsApplier.applyGuardedArrays(store, mainActions)}>
                <CardSection title="TestSession_Details">
                    <Row>
                        <DefaultCol>
                            <FormInput
                                label="TestSession_Name"
                                value={store.name}
                                onChange={store.setName}
                                validations={[required]}
                            />
                        </DefaultCol>
                        <DefaultCol>
                            <FormMultiSelect
                                label="TestSession_StudentGroups"
                                value={store.selectedGroups}
                                options={store.groups}
                                onChange={store.setSelectedGroups}
                                validations={[required]}
                            />
                        </DefaultCol>
                    </Row>
                </CardSection>
                <CardSection
                    title="TestSession_TestVariants"
                    actions={[
                        {
                            color: "primary",
                            icon: icons.add,
                            onClick: store.addNewTestVariant,
                        },
                    ]}
                >
                    <ListGroup>
                        {store.testVariants.map((tv, index) => (
                            <TestSessionVariant key={index} store={tv} />
                        ))}
                    </ListGroup>
                </CardSection>
                <AssessmentSection store={store.assessmentStore} />
            </CardSectionsGroup>
        </Form>
    );
});

const mainActions: GuardedActions<TestSessionDetailsEditStore> = [
    {
        data: store => [
            {
                text: "Cancel",
                color: "secondary",
                onClick: store.cancel,
            },
            {
                text: "Save",
                color: "primary",
            },
        ],
    },
];
