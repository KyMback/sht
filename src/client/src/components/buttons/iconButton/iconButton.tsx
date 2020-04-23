import { Button } from "reactstrap";
import { Icon } from "../../icons/icon";
import React from "react";
import { Color, KeyOrJSX } from "../../../typings/customTypings";
import { ensureLocal } from "../../../core/localization/local";

export interface IconButtonProps {
    color?: Color;
    icon?: string;
    text?: KeyOrJSX;
    onClick?: () => void;
}

export const IconButton = ({ icon, onClick, color, text }: IconButtonProps) => {
    return (
        <Button color={color} onClick={onClick}>
            {icon && <Icon icon={icon} />}
            {text && ensureLocal(text)}
        </Button>
    );
};
