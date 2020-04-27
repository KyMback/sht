import React from "react";
import { ButtonGroup } from "reactstrap";
import { KeyOrJSX } from "../../../typings/customTypings";
import { ensureLocal } from "../../../core/localization/local";
import { GenericButton, GenericButtonProps } from "../../buttons/genericButton/genericButton";

interface Props {
    children: React.ReactNode | React.ReactNodeArray;
    actions?: Array<GenericButtonProps>;
    topActions?: Array<GenericButtonProps>;
    title?: KeyOrJSX;
}

export const CardSectionsGroup = ({ children, actions, topActions, title }: Props) => {
    return (
        <div className="card-sections-group">
            {(title || topActions) && (
                <div className="top-actions justify-content-between align-items-center">
                    <h3>{ensureLocal(title)}</h3>
                    {topActions && (
                        <ButtonGroup>
                            {topActions.map((v, index) => (
                                <GenericButton key={index} {...v} />
                            ))}
                        </ButtonGroup>
                    )}
                </div>
            )}
            {children}
            {actions && (
                <div className="actions">
                    {actions.map((v, index) => (
                        <GenericButton key={index} {...v} />
                    ))}
                </div>
            )}
        </div>
    );
};
