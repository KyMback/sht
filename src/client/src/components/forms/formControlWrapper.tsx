import { Local } from "../../core/localization/local";
import React, { useContext, useEffect, useState } from "react";
import { ControlProps } from "../controls";
import { ValidationFunction } from "./validations";
import { FormGroup } from "reactstrap";
import { ValidationContext } from "./validationProvider";

export interface FormWrapperProps<TValue, TControlProps extends ControlProps<TValue>> {
    label: string;
    name?: string;
    control: React.FC<TControlProps>;
    controlProps: TControlProps;
    validations?: Array<ValidationFunction<TValue>>;
}

export const FormControlWrapper = <TValue, TControlProps extends ControlProps<TValue>>(
    {
        control: Control,
        label,
        name,
        controlProps,
        validations,
    }: FormWrapperProps<TValue, TControlProps>,
) => {
    const [isUsed, setIsUsed] = useState<boolean>(false);
    const context = useContext(ValidationContext);

    useEffect(() => {
        const validator = () => {
            setIsUsed(true);
            return !validate(controlProps.value, validations)
        };
        context.add(validator);
        return () => context.remove(validator);
    }, [context, controlProps.value, validations, isUsed]);

    const onChange = (value: TValue) => {
        setIsUsed(true);
        controlProps.onChange(value);
    };
    const error = validate(controlProps.value, validations);

    return (
        <FormGroup className={getClassNames(isUsed, error)}>
            <label htmlFor={name}><Local id={label}/></label>
            <Control id={name} {...controlProps} onChange={onChange}/>
            {isUsed && error && <ErrorMessage error={error}/>}
        </FormGroup>
    );
};

function getClassNames(isChanged: boolean, error?: string): string {
    return isChanged && error ? "invalid" : "";
}

function validate(value?: any, validations?: Array<ValidationFunction<any>>): string | undefined {
    if (!validations) {
        return;
    }
    for (const val of validations) {
        const result = val(value);
        if (result) {
            return result;
        }
    }
}

interface ErrorMessageProps {
    error: string;
}

const ErrorMessage = ({ error }: ErrorMessageProps) => {
    return (
        <span><Local id={`validation_${error}`}/></span>
    );
};
