import React, { createContext, forwardRef, PropsWithChildren, Ref, useImperativeHandle, useMemo } from "react";

type ValidatorType = () => boolean;

interface Context {
    add: (validator: ValidatorType) => void;
    remove: (validator: ValidatorType) => void;
}

export interface ValidationProviderHandlers {
    isValid: () => boolean;
}

class InternalContext implements Context {
    private validators: Array<ValidatorType> = [];

    public add = (validator: ValidatorType) => {
        this.validators = [...this.validators, validator];
    };

    public remove = (validator: ValidatorType) => {
        this.validators = this.validators.filter(v => v !== validator);
    };

    public isValid = (): boolean => {
        let result = true;
        for (const val of this.validators) {
            result = val() && result;
        }

        return result;
    };
}

export const ValidationContext = createContext<Context>(new InternalContext());

export const ValidationProvider = forwardRef<ValidationProviderHandlers, PropsWithChildren<object>>(
    ({ children }: PropsWithChildren<object>, ref: Ref<ValidationProviderHandlers>) => {
        const contextObject = useMemo<InternalContext>(() => new InternalContext(), []);
        useImperativeHandle(
            ref,
            () => ({
                isValid: contextObject.isValid,
            }),
            [contextObject],
        );

        return <ValidationContext.Provider value={contextObject}>{children}</ValidationContext.Provider>;
    },
);
