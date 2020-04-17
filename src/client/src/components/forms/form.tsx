import React, { FormEvent, forwardRef, PropsWithChildren, Ref, useCallback, useImperativeHandle, useRef } from "react";
import { Form as FormComponent } from "reactstrap";
import { ValidationProvider, ValidationProviderHandlers } from "./validationProvider";

interface Props {
    children: React.ReactNode | React.ReactNodeArray;
    onValidSubmit?: () => void;
    className?: string;
}

export interface FormActions {
    isValid: () => boolean;
}

export const Form = forwardRef(
    ({ onValidSubmit, children, className }: PropsWithChildren<Props>, ref: Ref<FormActions>) => {
        const validationProvider = useRef<ValidationProviderHandlers>(null);
        useImperativeHandle(
            ref,
            () => ({
                isValid: validationProvider.current!.isValid,
            }),
            [],
        );

        const submit = useCallback(
            (e: FormEvent) => {
                e.preventDefault();

                if (validationProvider.current!.isValid()) {
                    onValidSubmit && onValidSubmit();
                }
            },
            [onValidSubmit],
        );

        return (
            <FormComponent onSubmit={submit} className={className}>
                <ValidationProvider ref={validationProvider}>{children}</ValidationProvider>
            </FormComponent>
        );
    },
);
