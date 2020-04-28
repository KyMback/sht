import React from "react";
import { Local, LocalProps } from "../../localization/local";

export class ApiError {
    constructor(public response: Response, public code: string, public id?: string, public payload?: any) {}
}

export const apiErrors = {
    loginIsNotUniq: "6",
    invalidEmailConfirmationToken: "9",
    notConfirmedEmail: "10",
    studentTestSessionEnded: "11",
} as const;

export type ApiErrorType = typeof apiErrors[keyof typeof apiErrors];

export function isExpected(ex: any, ...codes: ApiErrorType[]) {
    return ex instanceof ApiError && codes!.length !== 0 && codes.some(code => ex.code === code);
}

interface LocalErrorProps extends Omit<LocalProps, "id"> {
    errorCode: ApiErrorType;
}

export const LocalError = ({ errorCode, ...rest }: LocalErrorProps) => (
    <Local id={`ErrorCode_${errorCode}`} {...rest} />
);
