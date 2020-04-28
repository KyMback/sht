import { ensureLocal } from "../../core/localization/local";
import React from "react";
import { KeyOrJSX } from "../../typings/customTypings";

interface Props {
    onClick: () => void;
    title?: KeyOrJSX;
    className?: string;
}

export const LinkButton = ({ title, onClick, className }: Props) => {
    return (
        <button
            className={`link-button ${className || ""}`}
            onClick={e => {
                e.preventDefault();
                onClick();
            }}
        >
            {ensureLocal(title)}
        </button>
    );
};
