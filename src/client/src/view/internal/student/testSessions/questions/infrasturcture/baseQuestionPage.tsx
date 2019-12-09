import { Form } from "../../../../../../components/forms/form";
import { CardSectionsGroup } from "../../../../../../components/layouts/sections/cardSectionsGroup";
import { CardSection } from "../../../../../../components/layouts/sections/cardSection";
import { Local } from "../../../../../../core/localization/local";
import React, { useContext, useMemo } from "react";
import { IdParams } from "../../../../../../typings/customTypings";
import { useParams } from "react-router-dom";
import { studentQuestionsContext } from "../studentQuestionsModule";
import { BaseQuestionStore } from "./baseQuestionStore";
import { QuestionType } from "../../../../../../typings/dataContracts";
import { FreeTextQuestion } from "../freeTextQuestion/freeTextQuestion";

export const BaseQuestionPage = () => {
    const params = useParams<IdParams>();
    const context = useContext(studentQuestionsContext);
    const store = context!.getOrCreateStore(params.id!);
    const component = useMemo(() => getComponent(store), [store]);

    return (
        <Form onValidSubmit={store.submit}>
            <CardSectionsGroup>
                <CardSection title={<Local id="Question_TitleTemplate" values={{ number: store.number }}/>}>
                    {component}
                </CardSection>
            </CardSectionsGroup>
        </Form>
    );
};

function getComponent(store: BaseQuestionStore) {
    switch (store.type) {
        case QuestionType.FreeText:
            return <FreeTextQuestion store={store}/>;
        default:
            throw new Error(`Invalid question type: ${store.type}`);
    }
}
