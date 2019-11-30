import { toast, ToastContainer } from "react-toastify";
import React from "react";
import { Local } from "../../core/localization/local";

export const NotificationsContainer = <ToastContainer position="top-center" hideProgressBar/>;

export const notifications = {
    error: (message: string) => toast.error(<Local id={message}/>),
    errorCode: (errorCode: string) => notifications.error(`ErrorCode_${errorCode}`),
    success: (message: string) => toast.success(<Local id={message}/>),
};
