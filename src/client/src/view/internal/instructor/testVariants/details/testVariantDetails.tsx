import React from "react";
import { observer, useLocalStore } from "mobx-react-lite";
import { TestVariantDetailsStore } from "./testVariantDetailsStore";
import { useParams } from "react-router-dom";
import { IdParams } from "../../../../../typings/customTypings";
import useAsyncEffect from "use-async-effect";
import { CardSectionsGroup } from "../../../../../components/layouts/sections/cardSectionsGroup";
import { routingStore } from "../../../../../stores/routingStore";
import { CardSection } from "../../../../../components/layouts/sections/cardSection";
import { Form } from "../../../../../components/forms/form";
import { FormInput } from "../../../../../components/forms";
import { required } from "../../../../../components/forms/validations";
import { GenericButtonProps } from "../../../../../components/buttons/genericButton/genericButton";

const actions: Array<GenericButtonProps> = [
    {
        text: "Cancel",
        color: "secondary",
        onClick: () => routingStore.goto("/test-variants/list"),
    },
    {
        text: "Save",
        color: "primary",
    },
];

export const TestVariantDetails = observer(() => {
    const params = useParams<IdParams>();
    const store = useLocalStore(() => new TestVariantDetailsStore(params.id));
    useAsyncEffect(store.loadData, []);

    return (
        <Form onValidSubmit={store.save}>
            <CardSectionsGroup title="TestVariant_Details" topActions={actions}>
                <CardSection title="TestVariant_DetailsSection">
                    <FormInput
                        label="TestVariant_Name"
                        value={store.name}
                        onChange={store.setName}
                        validations={[required]}
                    />
                </CardSection>
                {/*<CardSection title="TestVariant_Questions"></CardSection>*/}
            </CardSectionsGroup>
        </Form>
    );
});
