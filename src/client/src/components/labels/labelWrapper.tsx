import React from "react";
import { ensureLocal } from "../../core/localization/local";
import { KeyOrJSX } from "../../typings/customTypings";
import { Utils } from "../../core/utils/utils";

interface Props {
    title: KeyOrJSX;
    children: React.ReactNode;
    className?: string;
}

export const LabelWrapper = ({ title, children, className }: Props) => {
    return (
        <div className={Utils.css("labeled", className)}>
            <label>{ensureLocal(title)}</label>
            {children}
        </div>
    );
};
