import React, { createContext, forwardRef, PropsWithChildren, Ref, useImperativeHandle, useState } from "react";
import { pull } from "lodash";

interface Context {
    add: (validator: ValidationProviderHandlers) => void;
    remove: (validator: ValidationProviderHandlers) => void;
}

export interface ValidationProviderHandlers {
    isValid: () => boolean;
}

class InternalContext implements Context {
    private validators: Array<ValidationProviderHandlers> = [];

    public add = (validator: ValidationProviderHandlers) => {
        this.validators.push(validator);
    };

    public remove = (validator: ValidationProviderHandlers) => {
        pull(this.validators, validator);
    };

    public isValid = (): boolean => {
        let result = true;
        for (const val of this.validators) {
            result = val.isValid() && result;
        }

        return result;
    };
}

export const ValidationContext = createContext<Context>(new InternalContext());

export const ValidationProvider = forwardRef<ValidationProviderHandlers, PropsWithChildren<object>>(
    ({ children }: PropsWithChildren<object>, ref: Ref<ValidationProviderHandlers>) => {
        const [contextObject] = useState(new InternalContext());
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
