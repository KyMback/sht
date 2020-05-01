import { observer } from "mobx-react-lite";
import { PropsWithStore } from "../../../../../../../../typings/customTypings";
import { CardSection } from "../../../../../../../../components/layouts/sections/cardSection";
import { LabeledText } from "../../../../../../../../components/labels/labeled";
import { FreeTextQuestionViewSectionStore } from "./freeTextQuestionViewSectionStore";
import React from "react";

export const FreeTextQuestionViewSection = observer(({ store }: PropsWithStore<FreeTextQuestionViewSectionStore>) => {
    return (
        <CardSection>
            <LabeledText title="QuestionText" value={store.question} />
        </CardSection>
    );
});
