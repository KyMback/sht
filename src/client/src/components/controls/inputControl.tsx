import { Input } from "reactstrap";
import React, { useCallback } from "react";
import { ControlProps } from "./index";

export type TextInputValue = string | undefined;

export interface InputControlProps extends ControlProps<TextInputValue> {
    className?: string;
    type?: "password" | "text" | "email";
    valid?: boolean;
}

export const InputControl = ({ onChange, value, className, type, valid }: InputControlProps) => {
    const onChangeCallback = useCallback(
        e => {
            onChange && onChange(e.target.value);
        },
        [onChange],
    );

    return (
        <Input
            invalid={valid === undefined ? undefined : !valid}
            valid={valid}
            type={type || "text"}
            className={className}
            value={value || ""}
            onChange={onChangeCallback}
        />
    );
};
