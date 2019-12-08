import React, { useMemo } from "react";
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
}

export const SingleSelect = <TData extends any>(
    {
        value,
        onChange,
        options,
        valid,
        placeholder,
        className,
        isClearable,
    }: SingleSelectProps<TData>,
) => {
    const selectOptions = useMemo(() => mapSelectItemToOption(options), [options]);

    return (
        <ReactSelect
            className={`single-select ${valid ? "is-valid" : valid === false ? "is-invalid" : ""} ${className || ""}`}
            isSearchable
            isClearable={isClearable}
            backspaceRemovesValue
            placeholder={placeholder ? ensureLocal(placeholder) : <Local id="Select"/>}
            options={selectOptions}
            onChange={v => onChange(handleChange<TData>(v))}
            value={selectOptions.find(e => e.value === value)}
        />
    );
};

function mapSelectItemToOption<TData>(items: Array<SelectItem<TData>>): Array<any> {
    return items.map(o => ({ value: o.value, label: o.text }));
}

const handleChange = <TData extends any>(option: any): TData | undefined => {
    return option ? option.value : undefined;
};
