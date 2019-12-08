import React, { useMemo } from "react";
import { Button, Card, CardTitle } from "reactstrap";
import { KeyOrJSX } from "../../../typings/customTypings";
import { ensureLocal } from "../../../core/localization/local";
import { Icon } from "../../icons/icon";

interface Props {
    title?: KeyOrJSX;
    className?: string;
    children: React.ReactNode | React.ReactNodeArray;
    actions?: Array<SectionActionProps>;
}

export interface SectionActionProps {
    icon: string;
    onClick: () => void;
    color: "primary" | "secondary";
}

export const CardSection = (
    {
        title,
        className,
        children,
        actions,
    }: Props,
) => {
    const actionsComponent = useMemo(() => (
        <div className="actions">
            {actions && actions.map((item, index) => (
                <Button color={item.color} key={index} onClick={item.onClick}>
                    <Icon icon={item.icon}/>
                </Button>
            ))}
        </div>
    ), [actions]);
    const titleComponent = useMemo(() => (
        <div className="title">
            {ensureLocal(title)}
        </div>
    ), [title]);

    return (
        <Card className={`card-section ${className || ""}`} body>
            <CardTitle className="d-flex justify-content-between">
                {titleComponent}
                {actionsComponent}
            </CardTitle>
            {children}
        </Card>
    );
};
