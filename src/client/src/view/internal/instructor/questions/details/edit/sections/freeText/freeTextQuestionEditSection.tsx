import { observer } from "mobx-react-lite";
import { PropsWithStore } from "../../../../../../../../typings/customTypings";
import { CardSection } from "../../../../../../../../components/layouts/sections/cardSection";
import React from "react";
import { StoreFormsFactory } from "../../../../../../../../components/forms/factories/storeFormsFactory";
import { maxLargeLength, required } from "../../../../../../../../components/forms/validations";
import { FreeTextQuestionEditSectionStore } from "./freeTextQuestionEditSectionStore";

type Props = PropsWithStore<FreeTextQuestionEditSectionStore>;

const FormFields = StoreFormsFactory.new<FreeTextQuestionEditSectionStore>()
    .textArea("QuestionText", "question", undefined, [required, maxLargeLength])
    .build();

export const FreeTextQuestionEditSection = observer(({ store }: Props) => {
    return (
        <CardSection>
            <FormFields store={store} />
        </CardSection>
    );
});
