import { ColProps } from "reactstrap/lib/Col";
import { Col } from "reactstrap";
import React from "react";

type Props = ColProps;

export const DefaultCol = ({ children, ...rest }: Props) => {
    return (
        <Col xs={12} md={6} lg={4} xl={3} {...(rest as any)}>
            {children}
        </Col>
    );
};
