import { PropsWithStore } from "../../../../../../typings/customTypings";
import { AssessmentSectionStore } from "./assessmentSectionStore";
import { observer } from "mobx-react-lite";
import { CardSection } from "../../../../../../components/layouts/sections/cardSection";
import { SubSection } from "../../../../../../components/layouts/sections/subSection";
import { GuardedActions, GuardsApplier } from "../../../../../../core/guarding";
import { ListGroup } from "reactstrap";
import React from "react";
import { icons } from "../../../../../../components/icons/icon";
import { AnswersAssessmentQuestion } from "./answersAssessmentQuestion";

export const AssessmentSection = observer(({ store }: PropsWithStore<AssessmentSectionStore>) => {
    return (
        <CardSection title="TestSession_Assessment">
            <SubSection
                title="TestSession_AssessmentQuestions"
                actions={GuardsApplier.applyGuardedArrays(store, assessmentQuestionsActions)}
            >
                <ListGroup>
                    {store.answersAssessmentQuestions.map((data, index) => (
                        <AnswersAssessmentQuestion key={index} store={data} />
                    ))}
                </ListGroup>
            </SubSection>
        </CardSection>
    );
});

const assessmentQuestionsActions: GuardedActions<AssessmentSectionStore> = [
    {
        data: store => [
            {
                color: "primary",
                icon: icons.add,
                onClick: store.addNewAssessmentQuestion,
            },
        ],
    },
];
