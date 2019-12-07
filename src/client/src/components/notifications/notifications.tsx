import { toast, ToastContainer, ToastContainerProps } from "react-toastify";
import React from "react";
import { Local } from "../../core/localization/local";

const notificationsDefaults: ToastContainerProps = {
    autoClose: 8000,
    position: "top-center",
    hideProgressBar: true,
};

export const NotificationsContainer = <ToastContainer {...notificationsDefaults}/>;

export const notifications = {
    error: (message: string) => toast.error(<Local id={message}/>),
    errorCode: (errorCode: string) => notifications.error(`ErrorCode_${errorCode}`),
    success: (message: string) => toast.success(<Local id={message}/>),
};

