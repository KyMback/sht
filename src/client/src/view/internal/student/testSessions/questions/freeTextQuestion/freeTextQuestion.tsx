import React from "react";
import { observer } from "mobx-react-lite";
import { FreeTextQuestionStore } from "./freeTextQuestionStore";
import useAsyncEffect from "use-async-effect";
import { FormTextArea } from "../../../../../../components/forms";
import { required } from "../../../../../../components/forms/validations";

interface Props {
    store: FreeTextQuestionStore;
}

export const FreeTextQuestion = observer(({ store }: Props) => {
    useAsyncEffect(store.loadData, [store]);

    return (
        <>
            <span>{store.question}</span>
            <br/>
            <br/>
            <FormTextArea
                label="AnswerLabel"
                value={store.answer}
                onChange={store.setAnswer}
                validations={[required]}
            />
        </>
    );
});


