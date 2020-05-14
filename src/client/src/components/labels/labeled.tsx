import React from "react";
import { EnumLocal, Local } from "../../core/localization/local";
import { LabelWrapper } from "./labelWrapper";

interface Props<TValue> {
    title: string;
    value?: TValue;
    className?: string;
}

export function LabeledText({ value, ...rest }: Props<string>) {
    return <LabelWrapper {...rest}>{value || NoneContent}</LabelWrapper>;
}

export function LabeledEnum<TEnum extends string>({ value, enumObject, title }: Props<TEnum> & { enumObject: any }) {
    return (
        <LabelWrapper title={title}>
            {value ? <EnumLocal enumObject={enumObject} value={value} /> : NoneContent}
        </LabelWrapper>
    );
}

export const LabeledDateTime = ({ value, ...rest }: Props<string>) => {
    return <LabelWrapper {...rest}>{value || NoneContent}</LabelWrapper>;
};

const NoneContent = <Local id="None" />;
