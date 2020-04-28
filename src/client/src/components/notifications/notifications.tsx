import { toast, ToastContainer, ToastContainerProps } from "react-toastify";
import React from "react";
import { ensureLocal, Local } from "../../core/localization/local";
import { KeyOrJSX } from "../../typings/customTypings";
import { ApiErrorType, LocalError } from "../../core/api/http/apiError";

const notificationsDefaults: ToastContainerProps = {
    autoClose: 8000,
    position: "top-center",
    hideProgressBar: true,
    pauseOnHover: true,
    className: "notifications-container",
    toastClassName: "notification-toast",
    closeButton: false,
};

export const NotificationsContainer = () => <ToastContainer {...notificationsDefaults} />;

export const notifications = {
    error: (message: KeyOrJSX) => toast.error(ensureLocal(message)),
    errorCode: (errorCode: ApiErrorType) => notifications.error(<LocalError errorCode={errorCode} />),
    success: (message: string) => toast.success(<Local id={message} />),
    successfullySaved: () => toast.success(<Local id="SuccessfullySaved" />),
};
