import { Input } from "reactstrap";
import React from "react";
import { ControlProps } from "./index";

export interface InputControlProps extends ControlProps<string | undefined> {
    className?: string;
    type?: "password" | "text" | "email";
    valid?: boolean;
}

export const InputControl = (
    {
        onChange,
        value,
        className,
        type,
        valid,
    }: InputControlProps,
) => {
    return (
        <Input
            invalid={valid === undefined ? undefined : !valid}
            valid={valid}
            type={type || "text"}
            className={className}
            value={value || ""}
            onChange={e => onChange(e.target.value)}
        />
    );
};
