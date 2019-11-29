import { FormattedMessage } from "react-intl";
import { Dictionary } from "../../typings/customTypings";
import React from "react";

interface Props {
    id: string;
    values?: Dictionary;
}

export const Local = (props: Props) => <FormattedMessage {...props}/>;
