import { AccountService } from "../../../../services/accountService";
import { PasswordRulesDto, SignUpStudentDataDto } from "../../../../typings/dataContracts";
import { computed, observable, runInAction } from "mobx";
import { routingStore } from "../../../../stores/routingStore";
import { notifications } from "../../../../components/notifications/notifications";
import { apiErrors, isExpected } from "../../../../core/api/http/apiError";
import { AsyncInitializable } from "../../../../typings/customTypings";
import { ValidationFunction } from "../../../../components/forms/formControlWrapper";
import { required } from "../../../../components/forms/validations";
import { PasswordUtils } from "../../../../core/utils/passwordUtils";

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
        const passwordValidation = PasswordUtils.createPasswordValidation(this.passwordRules);
        return [required, passwordValidation];
    }

    @computed
    public get repeatPasswordValidation() {
        return this.repeatPassword !== this.password ? () => "repeatPasswordNotEqual" : () => undefined;
    }

    public signUp = async () => {
        try {
            await AccountService.signUpStudent(this.getDto());
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
        const passwordRules = await AccountService.getPasswordRules();

        runInAction(() => {
            this.passwordRules = passwordRules;
        });
    };

    private getDto = (): SignUpStudentDataDto => {
        return SignUpStudentDataDto.fromJS({
            email: this.email,
            password: this.password,
            firstName: this.firstName,
            lastName: this.lastName,
            group: this.group,
        });
    };
}
