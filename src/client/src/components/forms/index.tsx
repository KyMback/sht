import { InputControl, InputControlProps } from "../controls/inputControl";
import { makeFormControl } from "./formControls";

export const FormInput = makeFormControl<InputControlProps, string | undefined>(InputControl);
