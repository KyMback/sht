import { ControlProps } from "../index";
import React from "react";
import { InputControl } from "../inputControl";
import { localStore } from "../../../stores/localStore";

export type DurationValue = string | undefined;

export type DurationPickerProps = ControlProps<DurationValue>;

export const DurationPicker = (props: DurationPickerProps) => {
    return <InputControl {...props} placeholder={localStore.getLocalizedMessage("TimeSpanTemplate")} />;
};
