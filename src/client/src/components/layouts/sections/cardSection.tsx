import React from "react";
import { Card, CardTitle } from "reactstrap";
import { KeyOrJsx } from "../../../typings/customTypings";
import { ensureLocal } from "../../../core/localization/local";

interface Props {
    title?: KeyOrJsx;
    className?: string;
    children: React.ReactNode | React.ReactNodeArray;
}

export const CardSection = (
    {
        title,
        className,
        children,
    }: Props,
) => {
    return (
        <Card className={`card-section ${className || ""}`}>
            <CardTitle>{ensureLocal(title)}</CardTitle>
            {children}
        </Card>
    );
};
