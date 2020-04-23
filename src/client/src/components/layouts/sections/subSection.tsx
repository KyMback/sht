import React, { PropsWithChildren } from "react";
import { KeyOrJSX } from "../../../typings/customTypings";
import { ensureLocal } from "../../../core/localization/local";

interface Props {
    title?: KeyOrJSX;
}

export const SubSection = ({ children, title }: PropsWithChildren<Props>) => {
    return (
        <div className="sub-section">
            {title && <h4>{ensureLocal(title)}</h4>}
            <hr />
            {children}
        </div>
    );
};
