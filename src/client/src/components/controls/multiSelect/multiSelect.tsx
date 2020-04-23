import { ControlProps } from "../index";
import React from "react";
import ReactSelect from "react-select";
import { KeyOrJSX } from "../../../typings/customTypings";
import { ensureLocal, Local } from "../../../core/localization/local";

export interface MultiSelectProps<TData = any> extends ControlProps<Array<SelectItem<TData>> | undefined> {
    options: Array<SelectItem<TData>>;
    placeholder?: KeyOrJSX;
    className?: string;
    isSearchable?: boolean;
}

export interface SelectItem<TData> {
    text: string;
    value: TData;
    valueKey?: string;
}

export function MultiSelect<TData extends any>({
    value,
    onChange,
    options,
    valid,
    placeholder,
    className,
    isSearchable,
}: MultiSelectProps<TData>) {
    return (
        <ReactSelect<SelectItem<TData>>
            className={`multi-select ${valid ? "is-valid" : valid === false ? "is-invalid" : ""} ${className || ""}`}
            isSearchable={isSearchable}
            isMulti
            backspaceRemovesValue
            placeholder={placeholder ? ensureLocal(placeholder) : <Local id="SelectItems" />}
            options={options}
            onChange={v => onChange(handleChange<TData>(v))}
            getOptionValue={e => e.valueKey || (e.value as any)}
            getOptionLabel={e => e.text}
            value={value}
        />
    );
}

const handleChange = <TData extends any>(options: any): Array<SelectItem<TData>> => {
    if (Array.isArray(options)) {
        return options;
    } else if (options) {
        return [options];
    }

    return [];
};
