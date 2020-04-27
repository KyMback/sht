import { FormControlProps } from "../formControls";
import { InputControlProps } from "../../controls/inputControl";
import { TextArea, TextAreaProps } from "../../controls/textArea/textArea";
import { MultiSelect, MultiSelectProps } from "../../controls/multiSelect/multiSelect";
import { SingleSelect, SingleSelectProps } from "../../controls/singleSelect/singleSelect";
import { ControlProps } from "../../controls";
import React from "react";
import { LabelWrapper } from "../../labels/labelWrapper";

export const FormInputView = makeDefaultView<InputControlProps, string | undefined>();
export const FormTextAreaView = makeDefaultView<TextAreaProps, string | undefined>(props => (
    <TextArea {...props} disabled />
));
export const FormMultiSelectView = makeDefaultView<MultiSelectProps, Array<any> | undefined>(MultiSelect);
export const FormSingleSelectView = makeDefaultView<SingleSelectProps, any | undefined>(SingleSelect);

function makeDefaultView<TProps extends ControlProps<TValue>, TValue>(
    Control: React.FC<FormControlProps<TValue, TProps>> = props => <>{props.value}</>,
): React.FC<FormControlProps<TValue, TProps>> {
    return props => {
        return (
            <LabelWrapper title={props.label}>
                <Control {...props} />
            </LabelWrapper>
        );
    };
}
