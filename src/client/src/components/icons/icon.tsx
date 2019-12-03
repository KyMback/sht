import React from "react";

interface Props {
    icon: string;
}

export const icons = {
    account: "account_circle",
    add: "add",
    error: "error_outline",
};

export const Icon = ({ icon }: Props) => {
    return <i className="material-icons">{icon}</i>;
};
