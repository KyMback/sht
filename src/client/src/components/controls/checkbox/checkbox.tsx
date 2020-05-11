import { ControlProps } from "../index";
import { icons } from "../../icons/icon";
import React from "react";
import { ActionIcon } from "../../buttons/actionIcon/actionIcon";

export type CheckboxValue = boolean;

export type CheckboxProps = ControlProps<boolean>;

export const Checkbox = ({ value, onChange }: CheckboxProps) => {
    const icon = value ? icons.checked : icons.unchecked;

    return <ActionIcon className="text-primary" icon={icon} onClick={() => onChange && onChange(!value)} />;
};
