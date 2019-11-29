import { Input } from "reactstrap";
import React from "react";
import { ControlProps } from "./index";

interface Props extends ControlProps<string | undefined> {
    className?: string;
}

export const InputControl = (
    {
        onChange,
        value,
        className
    }: Props
) => {
    return (
        <Input
            className={className}
            value={value}
            onChange={e => onChange(e.target.value)}
        />
    )
};
