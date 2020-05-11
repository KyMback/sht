import React, { PropsWithChildren } from "react";
import { KeyOrJSX } from "../../../typings/customTypings";
import { ensureLocal } from "../../../core/localization/local";
import { CardSectionActionProps } from "./cardSection";
import { ActionsGroup } from "../actions/actionsGroup";

interface Props {
    title?: KeyOrJSX;
    actions?: Array<CardSectionActionProps>;
}

export const SubSection = ({ children, actions, title }: PropsWithChildren<Props>) => {
    return (
        <div className="sub-section">
            {(title || actions) && (
                <div className="d-flex">
                    {title && <h4>{ensureLocal(title)}</h4>}
                    {actions && <ActionsGroup className="ml-2" actions={actions} />}
                </div>
            )}
            <hr />
            {children}
        </div>
    );
};
