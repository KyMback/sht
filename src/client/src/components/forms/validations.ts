import { isEmpty } from "lodash";
import { ValidationFunction } from "./formControlWrapper";
import { LengthConstants } from "../../typings/lengthConstants";
import { DurationValue } from "../controls/durationPicker/durationPicker";
import { dateTimeRangeMask, zeroDateTimeRangeUnitMask } from "../../core/utils/durationUtils";

const emailRegexp = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;


export const required: ValidationFunction<any> = (value: any) => {
    return value == null || value === "" || requiredArray(value) ? "required" : undefined;
};

export const durationValidation: ValidationFunction<DurationValue> = (value: DurationValue) => {
    if (value == null) {
        return undefined;
    }

    return value && dateTimeRangeMask.test(value) && !value.split(" ").every(p => zeroDateTimeRangeUnitMask.test(p))
        ? undefined
        : "invalidDurationFormat";
};

export const nameShouldBeUniq = (values: Array<string | undefined>): ValidationFunction<string | undefined> => {
    return (value?: string) => {
        return values.filter(e => e === value).length > 1 ? "nameShouldBeUniq" : undefined;
    };
};

const requiredArray: ValidationFunction<Array<any>> = (value: Array<any>) => {
    return Array.isArray(value) && isEmpty(value) ? "required" : undefined;
};

export const emailValidation: ValidationFunction<string | undefined> = (value: string | undefined) => {
    return value && emailRegexp.test(value) ? undefined : "invalidEmailAddress";
};

export const maxLength = (maxLength: number): ValidationFunction<string | undefined> => (value?: string) => {
    if (!value) {
        return;
    }

    return value.length > maxLength ? "maxLength" : undefined;
};

export const maxSmallLength: ValidationFunction<string | undefined> = maxLength(LengthConstants.Small);
export const maxMediumLength: ValidationFunction<string | undefined> = maxLength(LengthConstants.Medium);
export const maxLargeLength: ValidationFunction<string | undefined> = maxLength(LengthConstants.Large);
