import React from "react";
import { Utils } from "../../core/utils/utils";

interface Props {
    icon: IconsType;
    className?: string;
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
    upload: "cloud_upload"
} as const;

export const Icon = ({ icon, className }: Props) => {
    return <i className={Utils.css("material-icons", className)}>{icon}</i>;
};
