import React from "react";
import { observer } from "mobx-react-lite";
import { FreeTextQuestionStore } from "./freeTextQuestionStore";
import useAsyncEffect from "use-async-effect";
import { LabeledText } from "../../../../../../components/labels/labeled";

interface Props {
    store: FreeTextQuestionStore;
}

export const FreeTextQuestion = observer(({ store }: Props) => {
    useAsyncEffect(store.loadData, [store]);

    return (
        <>
            <LabeledText title="Question" value={store.question}/>
        </>
    );
});


