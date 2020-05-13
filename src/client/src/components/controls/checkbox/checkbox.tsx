import { ControlProps } from "../index";
import { Icon, icons } from "../../icons/icon";
import React from "react";

export type CheckboxValue = boolean;

export type CheckboxProps = ControlProps<boolean>;

export const Checkbox = ({ value, onChange }: CheckboxProps) => {
    const icon = value ? icons.checked : icons.unchecked;

    return (
        <label className="custom-checkbox-container clickable d-block mb-0">
            <input type="checkbox" checked={value} onChange={() => onChange && onChange(!value)} />
            <Icon className="text-primary" icon={icon} />
        </label>
    );
};
