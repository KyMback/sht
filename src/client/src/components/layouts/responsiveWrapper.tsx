import React from "react";
import { Col, Row } from "reactstrap";

interface Props {
    colsInRow: number;
    children: React.ReactNodeArray;
}

export const ResponsiveWrapper = ({ children, colsInRow }: Props) => {
    const size = 12 / colsInRow;

    return (
        <Row>
            {children.map((item, index) => (
                <Col key={index} lg={size}>
                    {item}
                </Col>
            ))}
        </Row>
    );
};
