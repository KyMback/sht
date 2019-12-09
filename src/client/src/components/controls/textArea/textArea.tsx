import { ControlProps } from "../index";
import React from "react";

interface TextAreaProps extends ControlProps<string | undefined> {
    className: string;
}

export const TextArea = (
    {
        value,
        onChange,
        valid,
        className,
    }: TextAreaProps,
) => {
    return (
        <></>
    );
};
