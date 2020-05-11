import React from "react";
import { CardSectionActionProps } from "./cardSection";
import { ActionsGroup } from "../actions/actionsGroup";

interface Props {
    actions: Array<CardSectionActionProps>;
}

export const CardSectionBottomActions = ({ actions }: Props) => {
    return <ActionsGroup actions={actions} className="card-section-bottom-actions" />;
};
