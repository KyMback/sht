import { IconButton } from "../../buttons/iconButton/iconButton";
import React from "react";
import { CardSectionActionProps } from "./cardSection";

interface Props {
    actions: Array<CardSectionActionProps>;
}

export const CardSectionBottomActions = ({ actions }: Props) => {
    return (
        <div className="card-section-bottom-actions">
            {actions.map((item, index) => (
                <IconButton {...item} key={index} />
            ))}
        </div>
    );
};
