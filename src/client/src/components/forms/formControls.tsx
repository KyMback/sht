import { ControlProps } from "../controls";
import React from "react";
import { FormControlWrapper, FormWrapperProps } from "./formControlWrapper";

type FormControlProps<TValue, TProps extends ControlProps<TValue>> =
    Omit<FormWrapperProps<TValue, TProps>, "control" | "controlProps">
    & TProps;

export function makeFormControl<TProps extends ControlProps<TValue>, TValue>(
    control: React.FC<TProps>,
): React.FC<FormControlProps<TValue, TProps>> {
    return (props: FormControlProps<TValue, TProps>) => {
        return (
            <FormControlWrapper<TValue, TProps>
                control={control}
                controlProps={props}
                label={props.label}
                validations={props.validations}
            />
        );
    };
}
