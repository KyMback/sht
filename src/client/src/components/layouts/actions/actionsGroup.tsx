import { CardSectionActionProps } from "../sections/cardSection";
import { GenericButton } from "../../buttons/genericButton/genericButton";
import React from "react";
import { Utils } from "../../../core/utils/utils";

interface ActionsGroupProps {
    actions: Array<CardSectionActionProps>;
    className?: string;
}

export const ActionsGroup = ({ actions, className }: ActionsGroupProps) => {
    return (
        <div className={Utils.css("actions-group", className)}>
            {actions.map((item, index) => (
                <GenericButton {...item} key={index} />
            ))}
        </div>
    );
};
