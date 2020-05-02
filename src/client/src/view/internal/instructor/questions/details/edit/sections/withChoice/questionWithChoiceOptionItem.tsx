import { observer } from "mobx-react-lite";
import { PropsWithStore } from "../../../../../../../../typings/customTypings";
import { QuestionWithChoiceOptionStore } from "./questionWithChoiceOptionStore";
import { ListGroupItem, Row } from "reactstrap";
import { ActionIcon } from "../../../../../../../../components/buttons/actionIcon/actionIcon";
import { icons } from "../../../../../../../../components/icons/icon";
import { DefaultCol } from "../../../../../../../../components/layouts/defaultCol";
import { FormCheckbox, FormTextArea } from "../../../../../../../../components/forms";
import { maxLargeLength, required } from "../../../../../../../../components/forms/validations";
import React from "react";

export const QuestionWithChoiceOptionItem = observer(({ store }: PropsWithStore<QuestionWithChoiceOptionStore>) => {
    return (
        <ListGroupItem>
            <div className="d-flex justify-content-end">
                <ActionIcon icon={icons.close} onClick={store.delete} tooltip="Remove" />
            </div>
            <Row>
                <DefaultCol>
                    <FormTextArea
                        label="AnswerVariantText"
                        value={store.text}
                        onChange={store.setText}
                        validations={[required, maxLargeLength]}
                    />
                </DefaultCol>
                <DefaultCol>
                    <FormCheckbox label="IsCorrect" value={store.isCorrect} onChange={store.setIsCorrect} />
                </DefaultCol>
            </Row>
        </ListGroupItem>
    );
});
