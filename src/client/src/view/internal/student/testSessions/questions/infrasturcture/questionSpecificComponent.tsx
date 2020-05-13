import { observer } from "mobx-react-lite";
import { PropsWithStore } from "../../../../../../typings/customTypings";
import { BaseQuestionStore } from "./baseQuestionStore";
import { QuestionType } from "../../../../../../typings/dataContracts";
import { FreeTextQuestion } from "../freeTextQuestion/freeTextQuestion";
import { FreeTextQuestionStore } from "../freeTextQuestion/freeTextQuestionStore";
import { ChoiceQuestion } from "../choiceQuestions/choiceQuestion";
import { ChoiceQuestionStore } from "../choiceQuestions/choiceQuestionStore";
import { Local } from "../../../../../../core/localization/local";
import React from "react";

export const QuestionSpecificComponent = observer(({ store }: PropsWithStore<BaseQuestionStore>) => {
    switch (store.type) {
        case QuestionType.FreeText:
            return <FreeTextQuestion store={store as FreeTextQuestionStore} />;
        case QuestionType.QuestionWithChoice:
            return <ChoiceQuestion store={store as ChoiceQuestionStore} />;
        default:
            return <Local id="NotImplementedYet" />;
    }
});
