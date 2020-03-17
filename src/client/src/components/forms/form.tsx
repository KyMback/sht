import React, { FormEvent, PropsWithChildren, useCallback, useRef } from "react";
import { Form as FormComponent } from "reactstrap";
import { ValidationProvider, ValidationProviderHandlers } from "./validationProvider";

interface Props {
    children: React.ReactNode | React.ReactNodeArray;
    onValidSubmit?: () => void;
    className?: string;
}

export const Form = ({ onValidSubmit, children, className }: PropsWithChildren<Props>) => {
    const validationProvider = useRef<ValidationProviderHandlers>(null);

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
};
