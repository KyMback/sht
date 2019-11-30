export class ApiError {
    constructor(
        public response: Response,
        public code: string,
        public id?: string,
        public payload?: any,
    ) {
    }
}

export const apiErrors = {
    loginIsNotUniq: "6",
};

export function isExpected(ex: any, ...codes: string[]) {
    return ex instanceof ApiError
        && codes!.length !== 0
        && codes.some((code) => ex.code === code);
}
