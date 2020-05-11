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
        <Button color={color} onClick={onClick} className="d-flex">
            {icon && <Icon icon={icon} />}
            <span>{text && ensureLocal(text)}</span>
        </Button>
    );
};
