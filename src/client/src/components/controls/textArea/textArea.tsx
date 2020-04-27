import { ControlProps } from "../index";
import React, { useCallback } from "react";
import TextareaAutosize from "react-textarea-autosize";

export interface TextAreaProps extends ControlProps<string | undefined> {
    className?: string;
    minRows?: number;
    disabled?: boolean;
}

export const TextArea = ({ value, onChange, valid, className, minRows, disabled }: TextAreaProps) => {
    const validationClass = valid === undefined ? "" : valid ? "is-valid" : "is-invalid";
    const onChangeCallback = useCallback(
        e => {
            onChange && onChange(e.target.value);
        },
        [onChange],
    );

    return (
        <TextareaAutosize
            disabled={disabled}
            minRows={minRows || 3}
            className={`form-control ${validationClass} ${className || ""}`}
            value={value || ""}
            onChange={onChangeCallback}
        />
    );
};
