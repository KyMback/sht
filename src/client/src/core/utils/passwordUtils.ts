import { ValidationError, ValidationFunction } from "../../components/forms/formControlWrapper";

export interface PasswordRules {
    requireLowercase?: boolean;
    requireUppercase?: boolean;
    requireDigit?: boolean;
    requireNonAlphanumeric?: boolean;
    requiredLength?: number;
}

export class PasswordUtils {
    public static createPasswordValidation = (rules: PasswordRules): ValidationFunction<string | undefined> => {
        const validations: Array<ValidationFunction<string | undefined>> = [];

        if (rules.requiredLength) {
            const validation = PasswordUtils.getRequiredLengthValidation(rules.requiredLength);
            validations.push(validation);
        }

        if (rules.requireDigit) {
            validations.push(PasswordUtils.requireDigit);
        }
        if (rules.requireLowercase) {
            validations.push(PasswordUtils.requireLowercase);
        }
        if (rules.requireUppercase) {
            validations.push(PasswordUtils.requireUppercase);
        }
        if (rules.requireNonAlphanumeric) {
            validations.push(PasswordUtils.requireNonAlphanumeric);
        }

        return value => {
            const validation = validations.find(e => e(value));
            return validation && validation(value);
        };
    };

    private static requireDigit = (value?: string): ValidationError | undefined => {
        if (!value) {
            return;
        }

        return /\d/.test(value) ? undefined : "passwordRequireDigit";
    };

    private static requireLowercase = (value?: string): ValidationError | undefined => {
        if (!value) {
            return;
        }

        return /[a-z]/.test(value) ? undefined : "passwordRequireLowercase";
    };

    private static requireUppercase = (value?: string): ValidationError | undefined => {
        if (!value) {
            return;
        }

        return /[A-Z]/.test(value) ? undefined : "passwordRequireUppercase";
    };

    private static requireNonAlphanumeric = (value?: string): ValidationError | undefined => {
        if (!value) {
            return;
        }

        return /\W/.test(value) ? undefined : "passwordRequireNonAlphanumeric";
    };

    private static getRequiredLengthValidation = (requiredLength: number) => (
        value?: string,
    ): ValidationError | undefined => {
        if (!value) {
            return;
        }

        if (value.length < requiredLength) {
            return {
                key: "passwordRequiredLength",
                values: {
                    requiredLength,
                },
            };
        }
    };
}
