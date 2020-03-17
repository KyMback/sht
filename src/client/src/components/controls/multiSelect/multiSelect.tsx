import { ControlProps } from "../index";
import React, { useMemo } from "react";
import ReactSelect from "react-select";
import { KeyOrJSX } from "../../../typings/customTypings";
import { ensureLocal, Local } from "../../../core/localization/local";
import { isEmpty, some } from "lodash";

export interface MultiSelectProps<TData = any> extends ControlProps<Array<TData> | undefined> {
    options: Array<SelectItem<TData>>;
    placeholder?: KeyOrJSX;
    className?: string;
}

export interface SelectItem<TData> {
    text: string;
    value: TData;
}

interface InternalOption {
    label: string;
    value?: any;
}

export const MultiSelect = <TData extends any>({
    value,
    onChange,
    options,
    valid,
    placeholder,
    className,
}: MultiSelectProps<TData>) => {
    const selectOptions = useMemo(() => mapSelectItemToOption(options), [options]);

    return (
        <ReactSelect
            className={`multi-select ${valid ? "is-valid" : valid === false ? "is-invalid" : ""} ${className || ""}`}
            isSearchable
            isMulti
            backspaceRemovesValue
            placeholder={placeholder ? ensureLocal(placeholder) : <Local id="SelectItems" />}
            options={selectOptions}
            onChange={v => onChange(handleChange<TData>(v))}
            value={
                isEmpty(value) ? undefined : mapSelectItemToOption(options.filter(i => some(value, v => v === i.value)))
            }
        />
    );
};

function mapSelectItemToOption<TData>(items: Array<SelectItem<TData>>): Array<InternalOption> {
    return items.map(o => ({ value: o.value, label: o.text }));
}

const handleChange = <TData extends any>(options: any): Array<TData> => {
    let selectItems: Array<TData> = [];

    if (Array.isArray(options)) {
        selectItems = options.map(o => o.value);
    } else {
        if (options) {
            selectItems = [options.value];
        }
    }

    return selectItems;
};
