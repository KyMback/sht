import React, { useMemo } from "react";
import { Button, ButtonGroup } from "reactstrap";
import { Color, KeyOrJSX } from "../../../typings/customTypings";
import { ensureLocal } from "../../../core/localization/local";

interface Props {
    children: React.ReactNode | React.ReactNodeArray;
    actions?: Array<CardSectionActionConfigs>;
    topActions?: Array<CardSectionActionConfigs>;
    title?: KeyOrJSX;
}

export interface CardSectionActionConfigs {
    title: KeyOrJSX;
    onClick?: () => void;
    color?: Color;
}

export const CardSectionsGroup = (
    {
        children,
        actions,
        topActions,
        title,
    }: Props,
) => {
    const topActionsComponent = useMemo(() => {
        return topActions
            ? (
                <div className="top-actions justify-content-between align-items-center">
                    <h3>{ensureLocal(title)}</h3>
                    <ButtonGroup>
                        {
                            topActions.map((v, index) => (
                                <Button key={index} color={v.color} onClick={v.onClick}>
                                    {ensureLocal(v.title)}
                                </Button>
                            ))
                        }
                    </ButtonGroup>
                </div>
            )
            : null;
    }, [title, topActions]);
    const bottomActions = useMemo(() => {
        return actions
            ? (
                <div className="actions">
                    {
                        actions.map((v, index) => (
                            <Button color={v.color} key={index} onClick={v.onClick}>
                                {ensureLocal(v.title)}
                            </Button>
                        ))
                    }
                </div>
            )
            : null;
    }, [actions]);

    return (
        <div className="card-sections-group">
            {topActionsComponent}
            {children}
            {bottomActions}
        </div>
    );
};
