import React from "react";
import { Button } from "reactstrap";
import { KeyOrJSX } from "../../../typings/customTypings";
import { ensureLocal } from "../../../core/localization/local";

interface Props {
    children: React.ReactNode | React.ReactNodeArray;
    actions?: Array<CardSectionActionConfigs>;
    topActions?: Array<CardSectionActionConfigs>;
}

export interface CardSectionActionConfigs {
    title: KeyOrJSX;
    onClick?: () => void;
    color?: "primary" | "secondary";
}

export const CardSectionsGroup = (
    {
        children,
        actions,
        topActions,
    }: Props,
) => {
    return (
        <div className="card-sections-group">
            {topActions && <div className="top-actions">
                {
                    topActions.map((v, index) => (
                        <Button key={index} onClick={v.onClick}>
                            {ensureLocal(v.title)}
                        </Button>
                    ))
                }
            </div>}
            {children}
            <div className="actions">
                {
                    actions && actions.map((v, index) => (
                        <Button color={v.color} key={index} onClick={v.onClick}>
                            {ensureLocal(v.title)}
                        </Button>
                    ))
                }
            </div>
        </div>
    );
};
