import { isEmpty } from "lodash";

export type ValidationFunction<TValue> = (value: TValue) => string | undefined;

const emailRegexp = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

export const required: ValidationFunction<any> = (value: any) => {
    return !value || requiredArray(value)
        ? "required"
        : undefined;
}

export const nameShouldBeUniq = (values: Array<string | undefined>): ValidationFunction<string | undefined> => {
    return (value?: string) => {
            return values.filter(e => e === value).length > 1 ? "nameShouldBeUniq" : undefined;
    }
};

const requiredArray: ValidationFunction<Array<any>> = (value: Array<any>) => {
    return isEmpty(value) ? "required" : undefined;
};

export const emailValidation: ValidationFunction<string | undefined> = (value: string | undefined) => {
    return value && emailRegexp.test(value) ? undefined : "invalidEmailAddress";
};
