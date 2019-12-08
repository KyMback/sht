import { FormattedMessage } from "react-intl";
import { Dictionary, KeyOrJSX } from "../../typings/customTypings";
import React from "react";

interface Props {
    id: string;
    values?: Dictionary;
}

interface EnumLocalProps {
    enumObject: any;
    value: string;
}

const enumsMap: Map<any, string> = new Map<any, string>();

export const Local = (props: Props) => <FormattedMessage {...props}/>;
export const EnumLocal = ({ enumObject, value }: EnumLocalProps) =>
    <FormattedMessage id={getEnumKey(enumObject, value)}/>;

function getEnumKey(enumObject: any, value: string): string {
    const enumValue = enumsMap.get(enumObject);

    if(!enumValue) {
        throw new Error("You should first register enum via enumeration function");
    }

    return enumValue + "_" + value;
}

export const ensureLocal = (value?: KeyOrJSX) => {
    return typeof value === "string" ? <Local id={value}/> : value;
};

export function enumeration<T>(enumObject: T, name: string) {
    enumsMap.set(enumObject, name);
}
