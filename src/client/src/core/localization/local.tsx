import { FormattedMessage } from "react-intl";
import { Dictionary, KeyOrJsx } from "../../typings/customTypings";
import React from "react";

interface Props {
    id: string;
    values?: Dictionary;
}

export const Local = (props: Props) => <FormattedMessage {...props}/>;

export const ensureLocal = (value?: KeyOrJsx) => {
    return typeof value === "string" ? <Local id={value}/> : value;
};
