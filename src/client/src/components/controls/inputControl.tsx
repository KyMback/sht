import { Input } from "reactstrap";
import React from "react";
import { ControlProps } from "./index";

export interface InputControlProps extends ControlProps<string | undefined> {
    className?: string;
}

export const InputControl = (
    {
        onChange,
        value,
        className
    }: InputControlProps
) => {
    return (
        <Input
            className={className}
            value={value || ""}
            onChange={e => onChange(e.target.value)}
        />
    )
};
