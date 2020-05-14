import React, { useCallback, useEffect, useState } from "react";
import { Input } from "reactstrap";
import { ControlProps } from "../index";

export type NumericInputValue = number | undefined;

export interface NumericInputControlProps extends ControlProps<NumericInputValue> {
    className?: string;
    valid?: boolean;
}

export const NumericInputControl = ({ value, onChange, className, valid }: NumericInputControlProps) => {
    const [inputValue, setInputValue] = useState("");
    useEffect(() => {
        setInputValue(value == null ? "" : value.toString());
    }, [value]);

    const onChangeCallback = useCallback(
        (e: React.ChangeEvent<HTMLInputElement>) => {
            setInputValue(e.target.value);
            // Because Number("") == 0
            const number = e.target.value === "" ? undefined : Number(e.target.value);
            // required for support negative numbers (because they start with '-' char)
            if (number === undefined || !isNaN(number)) {
                onChange && onChange(number);
            }
        },
        [onChange],
    );

    return (
        <Input
            invalid={valid === undefined ? undefined : !valid}
            type={"number"}
            valid={valid}
            className={className}
            value={inputValue}
            onChange={onChangeCallback}
        />
    );
};
