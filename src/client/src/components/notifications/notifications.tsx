import { toast, ToastContainer, ToastContainerProps } from "react-toastify";
import React from "react";
import { ensureLocal, Local } from "../../core/localization/local";
import { KeyOrJSX } from "../../typings/customTypings";

const notificationsDefaults: ToastContainerProps = {
    autoClose: 8000,
    position: "top-center",
    hideProgressBar: true,
};

export const NotificationsContainer = () => <ToastContainer {...notificationsDefaults} />;

export const notifications = {
    error: (message: KeyOrJSX) => toast.error(ensureLocal(message)),
    errorCode: (errorCode: string) => notifications.error(`ErrorCode_${errorCode}`),
    success: (message: string) => toast.success(<Local id={message} />),
    successfullySaved: () => toast.success(<Local id="SuccessfullySaved" />),
};
