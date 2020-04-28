import { AccountService } from "../../../../services/accountService";
import { PasswordRulesDto, SignUpStudentDataDto, UserType } from "../../../../typings/dataContracts";
import { computed, observable, runInAction } from "mobx";
import { routingStore } from "../../../../stores/routingStore";
import { notifications } from "../../../../components/notifications/notifications";
import { apiErrors, isExpected } from "../../../../core/api/http/apiError";
import { AsyncInitializable } from "../../../../typings/customTypings";
import { HttpApi } from "../../../../core/api/http/httpApi";
import { ValidationError, ValidationFunction } from "../../../../components/forms/formControlWrapper";
import { required } from "../../../../components/forms/validations";

export class SignUpStudentStore implements AsyncInitializable {
    @observable public email?: string;
    @observable public firstName?: string;
    @observable public lastName?: string;
    @observable public group?: string;
    @observable public password?: string;
    @observable public repeatPassword?: string;

    @observable private passwordRules: PasswordRulesDto = new PasswordRulesDto();

    @computed
    public get passwordValidations(): Array<ValidationFunction<string | undefined>> {
        const validations = [required];

        validations.push(getRequiredLengthValidation(this.passwordRules.requiredLength));

        if (this.passwordRules.requireDigit) {
            validations.push(requireDigit);
        }
        if (this.passwordRules.requireLowercase) {
            validations.push(requireLowercase);
        }
        if (this.passwordRules.requireUppercase) {
            validations.push(requireUppercase);
        }
        if (this.passwordRules.requireNonAlphanumeric) {
            validations.push(requireNonAlphanumeric);
        }

        return validations;
    }

    @computed
    public get repeatPasswordValidation() {
        return this.repeatPassword !== this.password ? () => "repeatPasswordNotEqual" : () => undefined;
    }

    public signUp = async () => {
        try {
            await AccountService.signUpStudent(
                SignUpStudentDataDto.fromJS({
                    email: this.email,
                    password: this.password,
                    userType: UserType.Student,
                    firstName: this.firstName,
                    lastName: this.lastName,
                    group: this.group,
                }),
            );
        } catch (e) {
            if (isExpected(e, apiErrors.loginIsNotUniq)) {
                notifications.errorCode(apiErrors.loginIsNotUniq);
                return;
            }

            throw e;
        }

        notifications.success("SuccessfullyRegistered");
        routingStore.gotoBase();
    };

    public init = async () => {
        const { passwordRules } = await HttpApi.graphQl<{ passwordRules: PasswordRulesDto }>(passwordRulesQuery);

        runInAction(() => {
            this.passwordRules = passwordRules;
        });
    };
}

const passwordRulesQuery = `
{
  passwordRules {
    requireDigit
    requiredLength
    requireLowercase
    requireNonAlphanumeric
    requireUppercase
  }
}
`;

const getRequiredLengthValidation = (requiredLength: number) => (value?: string): ValidationError | undefined => {
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

const requireDigit = (value?: string): ValidationError | undefined => {
    if (!value) {
        return;
    }

    return /\d/.test(value) ? undefined : "passwordRequireDigit";
};

const requireLowercase = (value?: string): ValidationError | undefined => {
    if (!value) {
        return;
    }

    return /[a-z]/.test(value) ? undefined : "passwordRequireLowercase";
};

const requireUppercase = (value?: string): ValidationError | undefined => {
    if (!value) {
        return;
    }

    return /[A-Z]/.test(value) ? undefined : "passwordRequireUppercase";
};

const requireNonAlphanumeric = (value?: string): ValidationError | undefined => {
    if (!value) {
        return;
    }

    return /\W/.test(value) ? undefined : "passwordRequireNonAlphanumeric";
};
