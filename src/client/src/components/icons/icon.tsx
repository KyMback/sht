import React from "react";

interface Props {
    icon: IconsType;
}

export type IconsType = typeof icons[keyof typeof icons];

export const icons = {
    account: "account_circle",
    add: "add",
    error: "error_outline",
    delete: "delete_forever",
    close: "close",
    language: "language",
    checked: "check_box",
    unchecked: "check_box_outline_blank",
    expand: "expand_more",
    unExpand: "expand_less",
} as const;

export const Icon = ({ icon }: Props) => {
    return <i className="material-icons">{icon}</i>;
};
