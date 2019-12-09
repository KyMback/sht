import { InputControl, InputControlProps } from "../controls/inputControl";
import { makeFormControl } from "./formControls";
import { MultiSelect, MultiSelectProps } from "../controls/multiSelect/multiSelect";
import { SingleSelect, SingleSelectProps } from "../controls/singleSelect/singleSelect";
import { TextArea, TextAreaProps } from "../controls/textArea/textArea";

export const FormInput = makeFormControl<InputControlProps, string | undefined>(InputControl);
export const FormTextArea = makeFormControl<TextAreaProps, string | undefined>(TextArea);
export const FormMultiSelect = makeFormControl<MultiSelectProps, Array<any> | undefined>(MultiSelect);
export const FormSingleSelect = makeFormControl<SingleSelectProps, any | undefined>(SingleSelect);
