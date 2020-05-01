import { SingleSelect, SingleSelectProps } from "../singleSelect/singleSelect";
import React, { useMemo } from "react";
import { SelectItem } from "../multiSelect/multiSelect";
import { getEnumValue } from "../../../core/localization/local";
import { keys } from "lodash";

export type EnumSelectValue = string | undefined | any;

export interface EnumSelectProps extends Omit<SingleSelectProps<EnumSelectValue>, "options"> {
    enumObject: any;
}

export function EnumSelect({ enumObject, ...rest }: EnumSelectProps) {
    const options = useMemo(() => getEnumSelectItems<EnumSelectValue>(enumObject), [enumObject]);
    return <SingleSelect<EnumSelectValue> {...rest} options={options} />;
}

function getEnumSelectItems<EnumSelectValue>(enumObject: any): Array<SelectItem<EnumSelectValue>> {
    return keys(enumObject).map(e => ({
        text: getEnumValue(enumObject, enumObject[e]),
        value: enumObject[e],
    }));
}
