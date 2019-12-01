import React from "react";
import { Button } from "reactstrap";
import { KeyOrJSX } from "../../../typings/customTypings";
import { ensureLocal } from "../../../core/localization/local";

interface Props {
    children: React.ReactNode | React.ReactNodeArray;
    actions?: Array<CardSectionActionConfigs>;
}

export interface CardSectionActionConfigs {
    title: KeyOrJSX;
    onClick?: () => void;
}

export const CardSectionsGroup = (
    {
        children,
        actions,
    }: Props,
) => {
    return (
        <div>
            {children}
            <div className="actions">
                {
                    actions && actions.map((v, index) => (
                        <Button key={index} onClick={v.onClick}>
                            {ensureLocal(v.title)}
                        </Button>
                    ))
                }
            </div>
        </div>
    );
};
