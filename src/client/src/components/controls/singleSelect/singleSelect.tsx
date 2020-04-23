import React from "react";
import ReactSelect from "react-select";
import { ensureLocal, Local } from "../../../core/localization/local";
import { SelectItem } from "../multiSelect/multiSelect";
import { ControlProps } from "../index";
import { KeyOrJSX } from "../../../typings/customTypings";

export interface SingleSelectProps<TData = any> extends ControlProps<TData | undefined> {
    options: Array<SelectItem<TData>>;
    placeholder?: KeyOrJSX;
    className?: string;
    isClearable?: boolean;
    isSearchable?: boolean;
}

export function SingleSelect<TData extends any>({
    value,
    onChange,
    options,
    valid,
    placeholder,
    className,
    isClearable,
    isSearchable,
}: SingleSelectProps<TData>) {
    return (
        <ReactSelect<SelectItem<TData>>
            className={`single-select ${valid ? "is-valid" : valid === false ? "is-invalid" : ""} ${className || ""}`}
            isSearchable={isSearchable}
            isClearable={isClearable}
            backspaceRemovesValue
            placeholder={placeholder ? ensureLocal(placeholder) : <Local id="Select" />}
            options={options}
            onChange={v => onChange(handleChange<TData>(v))}
            getOptionValue={e => e.valueKey || (e.value as any)}
            getOptionLabel={e => e.text}
            value={options.find(e => e.value === value)}
        />
    );
}

const handleChange = <TData extends any>(option: any): TData | undefined => {
    return option ? option.value : undefined;
};
