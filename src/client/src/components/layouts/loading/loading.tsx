import React from "react";
import loading from "../../../static/images/loading.gif";

interface Props {
    className: string;
}

export const Loading = ({ className }: Props) => <img className={className} src={loading} alt="Loading" />;
