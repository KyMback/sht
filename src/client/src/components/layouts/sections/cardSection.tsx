import React from "react";
import { Button, Card, CardTitle } from "reactstrap";
import { KeyOrJSX } from "../../../typings/customTypings";
import { ensureLocal } from "../../../core/localization/local";
import { Icon } from "../../icons/icon";

interface Props {
    title?: KeyOrJSX;
    className?: string;
    children: React.ReactNode | React.ReactNodeArray;
    actions?: Array<ActionProps>;
}

interface ActionProps {
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
    return (
        <Card className={`card-section ${className || ""}`} body>
            <CardTitle className="d-flex justify-content-between">
                {ensureLocal(title)}
                <div className="actions">
                    {actions && actions.map((item, index) => (
                        <Button color={item.color} key={index} onClick={item.onClick}>
                            <Icon icon={item.icon}/>
                        </Button>
                    ))}
                </div>
            </CardTitle>
            {children}
        </Card>
    );
};
