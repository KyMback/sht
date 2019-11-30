export type ValidationFunction<TValue> = (value: TValue) => string | undefined;

export const required: ValidationFunction<any> = (value: any) => {
    return !value ? "required" : undefined;
};
