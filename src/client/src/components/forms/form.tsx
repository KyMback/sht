import React, { FormEvent, useRef } from "react";
import { Form as FormComponent } from "reactstrap";
import { ValidationProvider } from "./validationProvider";

interface Props {
    children: React.ReactNode | React.ReactNodeArray;
    onValidSubmit?: () => void;
}

export const Form = ({ onValidSubmit, children }: Props) => {
    const validationProvider = useRef<ValidationProvider>(null);

    const submit = (e: FormEvent) => {
        e.preventDefault();

        if (validationProvider.current!.validate()) {
            onValidSubmit && onValidSubmit();
        }
    };

    return (
        <FormComponent onSubmit={submit}>
            <ValidationProvider ref={validationProvider}>{children}</ValidationProvider>
        </FormComponent>
    );
};
