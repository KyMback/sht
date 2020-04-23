import React from "react";
import { Card, CardTitle } from "reactstrap";
import { KeyOrJSX } from "../../../typings/customTypings";
import { ensureLocal } from "../../../core/localization/local";
import { IconButton, IconButtonProps } from "../../buttons/iconButton/iconButton";
import { CardSectionBottomActions } from "./cardSectionBottomActions";

interface Props {
    title?: KeyOrJSX;
    className?: string;
    children: React.ReactNode | React.ReactNodeArray;
    actions?: Array<CardSectionActionProps>;
    bottomActions?: Array<CardSectionActionProps>;
}

export type CardSectionActionProps = IconButtonProps;

export const CardSection = ({ title, className, children, actions, bottomActions }: Props) => {
    return (
        <Card className={`card-section ${className || ""}`} body>
            {(title || actions) && (
                <CardTitle className="d-flex justify-content-between">
                    {title && <div className="title">{ensureLocal(title)}</div>}
                    {actions && (
                        <div className="actions">
                            {actions.map((item, index) => (
                                <IconButton {...item} key={index} />
                            ))}
                        </div>
                    )}
                </CardTitle>
            )}
            {children}
            {bottomActions && <CardSectionBottomActions actions={bottomActions} />}
        </Card>
    );
};
