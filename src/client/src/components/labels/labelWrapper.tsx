import React from "react";
import { ensureLocal } from "../../core/localization/local";
import { KeyOrJSX } from "../../typings/customTypings";

interface Props {
    title: KeyOrJSX;
    children: React.ReactNode;
}

export const LabelWrapper = (
    {
        title,
        children,
    }: Props,
) => {
    return (
        <div className="labeled">
            <label>{ensureLocal(title)}</label>
            {children}
        </div>
    );
};
