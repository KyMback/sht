import { InputControl, InputControlProps, TextInputValue } from "../controls/inputControl";
import { makeFormControl } from "./formControls";
import { MultiSelect, MultiSelectProps } from "../controls/multiSelect/multiSelect";
import { SingleSelect, SingleSelectProps, SingleSelectValue } from "../controls/singleSelect/singleSelect";
import { TextArea, TextAreaProps } from "../controls/textArea/textArea";
import { FormInputView } from "./view";
import { EnumSelect, EnumSelectProps, EnumSelectValue } from "../controls/enumSelect/enumSelect";
import { Checkbox, CheckboxProps, CheckboxValue } from "../controls/checkbox/checkbox";
import {
    NumericInputControl,
    NumericInputControlProps,
    NumericInputValue,
} from "../controls/numericInput/numericInput";
import { SimpleFilesUpload, SimpleFilesUploadProps, SimpleFilesUploadValue } from "../controls/files/simpleFilesUpload";
import {
    SimpleSingleFileUpload,
    SimpleSingleFileUploadProps,
    SimpleSingleFileUploadValue,
} from "../controls/files/simpleSingleFileUpload";

export const FormInput = makeFormControl<InputControlProps, TextInputValue>(InputControl, FormInputView);
export const FormNumericInput = makeFormControl<NumericInputControlProps, NumericInputValue>(NumericInputControl);
export const FormTextArea = makeFormControl<TextAreaProps, TextInputValue>(TextArea);
export const FormMultiSelect = makeFormControl<MultiSelectProps, Array<any> | undefined>(MultiSelect);
export const FormSingleSelect = makeFormControl<SingleSelectProps, SingleSelectValue<any>>(SingleSelect);
export const FormEnumSelect = makeFormControl<EnumSelectProps, EnumSelectValue>(EnumSelect);
export const FormCheckbox = makeFormControl<CheckboxProps, CheckboxValue>(Checkbox);
export const FormSimpleFilesUpload = makeFormControl<SimpleFilesUploadProps, SimpleFilesUploadValue>(SimpleFilesUpload);
export const FormSimpleSingleFileUpload = makeFormControl<SimpleSingleFileUploadProps, SimpleSingleFileUploadValue>(
    SimpleSingleFileUpload,
);
