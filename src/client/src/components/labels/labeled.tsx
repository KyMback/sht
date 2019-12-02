import React from "react";
import { Local } from "../../core/localization/local";
import { LabelWrapper } from "./labelWrapper";

interface Props<TValue> {
    title: string;
    value?: TValue;
}

export const LabeledText = (props: Props<string>) => {
    return (
        <LabelWrapper title={props.title}>
            {props.value || NoneContent}
        </LabelWrapper>
    );
};

export const LabeledDateTime = ({ value, title }: Props<string>) => {
    return (
        <LabelWrapper title={title}>
            {value || NoneContent}
        </LabelWrapper>
    );
};

const NoneContent = <Local id="None"/>;

