import { Local } from "../../core/localization/local";
import React, { useContext, useEffect, useMemo, useState } from "react";
import { ControlProps } from "../controls";
import { ValidationFunction } from "./validations";
import { FormGroup } from "reactstrap";
import { ValidationContext } from "./validationProvider";
import { Icon, icons } from "../icons/icon";

export interface FormWrapperProps<TValue, TControlProps extends ControlProps<TValue>> {
    label: string;
    name?: string;
    control: React.FC<TControlProps>;
    controlProps: TControlProps;
    validations?: Array<ValidationFunction<TValue>>;
}

export const FormControlWrapper = <TValue, TControlProps extends ControlProps<TValue>>({
    control: Control,
    label,
    name,
    controlProps,
    validations,
}: FormWrapperProps<TValue, TControlProps>) => {
    const [isUsed, setIsUsed] = useState<boolean>(false);
    const context = useContext(ValidationContext);

    useEffect(() => {
        const validator = () => {
            setIsUsed(true);
            return !validate(controlProps.value, validations);
        };
        context.add(validator);
        return () => context.remove(validator);
    }, [context, controlProps.value, validations, isUsed]);

    const onChange = (value: TValue) => {
        setIsUsed(true);
        controlProps.onChange(value);
    };

    const error = validate(controlProps.value, validations);

    const serializerProps = JSON.stringify(controlProps);
    const memoControl = useMemo(
        () => <Control id={name} {...controlProps} valid={!isUsed ? undefined : !error} onChange={onChange} />,
        // eslint-disable-next-line react-hooks/exhaustive-deps
        [serializerProps, isUsed, name, error],
    );
    const errorMessage = useMemo(() => isUsed && error && <ErrorMessage error={error} />, [error, isUsed]);

    return (
        <FormGroup className={`form-control-wrapper ${getClassNames(isUsed, error)}`}>
            <label htmlFor={name}>
                <Local id={label} />
            </label>
            {memoControl}
            {errorMessage}
        </FormGroup>
    );
};

function getClassNames(isUsed: boolean, error?: string): string {
    const classNames = [];

    if (isUsed && error) {
        classNames.push("invalid");
    }

    return classNames.join(" ");
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
        <span className="validation-error">
            <Icon icon={icons.error} />
            <Local id={`validation_${error}`} />
        </span>
    );
};
