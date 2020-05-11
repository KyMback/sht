import React from "react";
import { Card, CardTitle } from "reactstrap";
import { KeyOrJSX } from "../../../typings/customTypings";
import { ensureLocal } from "../../../core/localization/local";
import { GenericButtonProps } from "../../buttons/genericButton/genericButton";
import { CardSectionBottomActions } from "./cardSectionBottomActions";
import { ActionsGroup } from "../actions/actionsGroup";

interface Props {
    title?: KeyOrJSX;
    className?: string;
    children: React.ReactNode | React.ReactNodeArray;
    actions?: Array<CardSectionActionProps>;
    bottomActions?: Array<CardSectionActionProps>;
}

export type CardSectionActionProps = GenericButtonProps;

export const CardSection = ({ title, className, children, actions, bottomActions }: Props) => {
    return (
        <Card className={`card-section ${className || ""}`} body>
            {(title || actions) && (
                <CardTitle className="d-flex justify-content-between">
                    {title && <div className="title">{ensureLocal(title)}</div>}
                    {actions && <ActionsGroup actions={actions} />}
                </CardTitle>
            )}
            {children}
            {bottomActions && <CardSectionBottomActions actions={bottomActions} />}
        </Card>
    );
};
