import { ensureLocal, Local } from "../../core/localization/local";
import React, { useMemo } from "react";
import { ControlProps } from "../controls";
import { FormGroup, Label } from "reactstrap";
import { ValidationContext } from "./validationProvider";
import { Icon, icons } from "../icons/icon";
import { KeyOrJSX } from "../../typings/customTypings";
import { required } from "./validations";

export interface FormWrapperProps<TValue, TControlProps extends ControlProps<TValue>> {
    label?: KeyOrJSX;
    name?: string;
    control: React.FC<TControlProps>;
    controlProps: TControlProps;
    validations?: Array<ValidationFunction<TValue>>;
}

export interface DetailedValidationError {
    key: string;
    values?: any;
}

export type ValidationError = string | DetailedValidationError;

export type ValidationFunction<TValue> = (value: TValue) => ValidationError | undefined;

function withValidation<TValue, TControlProps extends ControlProps<TValue>>(
    Control: React.FC<FormWrapperProps<TValue, TControlProps> & ValidationResultProps>,
): React.ComponentType<FormWrapperProps<TValue, TControlProps>> {
    return class extends React.Component<FormWrapperProps<TValue, TControlProps>, { isUsed: boolean }> {
        static contextType = ValidationContext;
        context!: React.ContextType<typeof ValidationContext>;

        constructor(props: any) {
            super(props);
            this.state = {
                isUsed: false,
            };
        }

        public componentDidMount(): void {
            this.context.add(this);
        }

        public componentWillUnmount(): void {
            this.context.remove(this);
        }

        public isValid = (): boolean => {
            this.setState({
                isUsed: true,
            });
            return !validate(this.props.controlProps.value, this.props.validations);
        };

        private onChange = (value: TValue) => {
            this.props.controlProps.onChange(value);
            this.setState({
                isUsed: true,
            });
        };

        public render = () => {
            const validations = this.props.validations;

            return (
                <Control
                    {...this.props}
                    {...this.state}
                    error={validate(this.props.controlProps.value, validations)}
                    controlProps={{ ...this.props.controlProps, onChange: this.onChange }}
                    isRequired={validations ? validations.some(e => e === required) : false}
                />
            );
        };
    };
}

interface ValidationResultProps {
    isUsed: boolean;
    isRequired: boolean;
    error?: ValidationError;
}

export const FormControlWrapper = withValidation(
    <TValue, TControlProps extends ControlProps<TValue>>({
        control: Control,
        label,
        name,
        controlProps,
        isUsed,
        error,
        isRequired,
    }: FormWrapperProps<TValue, TControlProps> & ValidationResultProps) => {
        const errorMessage = useMemo(() => isUsed && error && <ErrorMessage error={error} />, [error, isUsed]);
        const labelComponent = useMemo(() => label && ensureLocal(label), [label]);

        return (
            <FormGroup className={`form-control-wrapper ${getClassNames(isUsed, error)}`}>
                <Label required={true} aria-required={isRequired} htmlFor={name}>
                    {labelComponent}
                    <span className="text-danger">{isRequired ? "*" : ""}</span>
                </Label>
                <Control id={name} {...controlProps} valid={!isUsed ? undefined : !error} isRequired={isRequired} />
                {errorMessage}
            </FormGroup>
        );
    },
);

function getClassNames(isUsed: boolean, error?: ValidationError): string {
    const classNames = [];

    if (isUsed && error) {
        classNames.push("invalid");
    }

    return classNames.join(" ");
}

function validate(value?: any, validations?: Array<ValidationFunction<any>>): ValidationError | undefined {
    if (!validations) {
        return;
    }
    for (const val of validations) {
        const error = val(value);
        if (error) {
            return error;
        }
    }
}

interface ErrorMessageProps {
    error: ValidationError;
}

const ErrorMessage = ({ error }: ErrorMessageProps) => {
    return (
        <span className="validation-error">
            <Icon icon={icons.error} />
            <ErrorLocal error={error} />
        </span>
    );
};

const ErrorLocal = ({ error }: ErrorMessageProps) => {
    if (typeof error === "string") {
        return <Local id={`validation_${error}`} />;
    } else {
        return <Local id={`validation_${error.key}`} values={error.values} />;
    }
};
