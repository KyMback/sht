import { Input } from "reactstrap";
import React from "react";
import { ControlProps } from "./index";

export interface InputControlProps extends ControlProps<string | undefined> {
    className?: string;
    type?: "password" | "text";
}

export const InputControl = (
    {
        onChange,
        value,
        className,
        type,
    }: InputControlProps,
) => {
    return (
        <Input
            type={type || "text"}
            className={className}
            value={value || ""}
            onChange={e => onChange(e.target.value)}
        />
    );
};
