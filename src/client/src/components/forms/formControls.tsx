import { ControlProps } from "../controls";
import React from "react";
import { FormControlWrapper, FormWrapperProps } from "./formControlWrapper";
import { ViewModesSwitcher } from "./view/core/viewModesSwitcher";

export type FormControlProps<TValue, TProps extends ControlProps<TValue>> = Omit<
    FormWrapperProps<TValue, TProps>,
    "control" | "controlProps"
> &
    TProps;

export function makeFormControl<TProps extends ControlProps<TValue>, TValue>(
    control: React.FC<TProps>,
    view?: React.FC<TProps>,
): React.FC<FormControlProps<TValue, TProps>> {
    const editControl = (props: FormControlProps<TValue, TProps>) => {
        return (
            // eslint-disable-next-line @typescript-eslint/ban-ts-ignore
            // @ts-ignore
            <FormControlWrapper<TValue, TProps>
                control={control}
                controlProps={props}
                label={props.label}
                validations={props.validations}
            />
        );
    };

    return view ? props => <ViewModesSwitcher edit={editControl} view={view} props={props} /> : editControl;
}
