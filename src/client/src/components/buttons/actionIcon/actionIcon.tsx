import { Icon } from "../../icons/icon";
import React, { useMemo } from "react";
import { UncontrolledTooltip } from "reactstrap";
import { uniqId } from "../../../core/utils/uniqIdUtil";
import { KeyOrJSX } from "../../../typings/customTypings";
import { ensureLocal } from "../../../core/localization/local";

interface Props {
    icon: string;
    onClick: () => void;
    tooltip?: KeyOrJSX;
    className?: string;
}

export const ActionIcon = ({ icon, onClick, tooltip, className }: Props) => {
    const id = useMemo(() => uniqId("tooltip_"), []);
    const tooltipComponent = useMemo(() => (tooltip &&
        <UncontrolledTooltip target={id}>{ensureLocal(tooltip)}</UncontrolledTooltip>), [id, tooltip]);

    return (
        <div id={id} className={`action-icon ${className || ""}`} onClick={onClick}>
            <Icon icon={icon}/>
            {tooltipComponent}
        </div>
    );
};
