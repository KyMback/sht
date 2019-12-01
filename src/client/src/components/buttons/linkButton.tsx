import { ensureLocal } from "../../core/localization/local";
import React from "react";
import { KeyOrJSX } from "../../typings/customTypings";

interface Props {
    onClick: () => void;
    title?: KeyOrJSX;
}

export const LinkButton = (
    {
        title,
        onClick,
    }: Props,
) => {
    return (
        <button className="link-button" onClick={e => {
            e.preventDefault();
            onClick();
        }}>{ensureLocal(title)}</button>
    );
};
