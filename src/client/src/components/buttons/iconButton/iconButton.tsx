import { Button } from "reactstrap";
import { Icon } from "../../icons/icon";
import React from "react";
import { Color } from "../../../typings/customTypings";

interface Props {
    color?: Color;
    icon: string;
    onClick: () => void;
}

export const IconButton = ({ icon, onClick, color }: Props) => {
    return (
        <Button color={color} onClick={onClick}>
            <Icon icon={icon}/>
        </Button>
    );
};
