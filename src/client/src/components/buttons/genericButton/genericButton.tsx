import { Button } from "reactstrap";
import { Icon, IconsType } from "../../icons/icon";
import React from "react";
import { Color, KeyOrJSX } from "../../../typings/customTypings";
import { ensureLocal } from "../../../core/localization/local";

export interface GenericButtonProps {
    color?: Color;
    icon?: IconsType;
    text?: KeyOrJSX;
    onClick?: () => void;
}

export const GenericButton = ({ icon, onClick, color, text }: GenericButtonProps) => {
    return (
        <Button color={color} onClick={onClick}>
            {icon && <Icon icon={icon} />}
            {text && ensureLocal(text)}
        </Button>
    );
};
