import { computed, observable, runInAction } from "mobx";
import { PasswordRulesDto, SignUpInstructorDataDto } from "../../../../typings/dataContracts";
import { ValidationFunction } from "../../../../components/forms/formControlWrapper";
import { required } from "../../../../components/forms/validations";
import { PasswordUtils } from "../../../../core/utils/passwordUtils";
import { AccountService } from "../../../../services/accountService";
import { apiErrors, isExpected } from "../../../../core/api/http/apiError";
import { notifications } from "../../../../components/notifications/notifications";
import { routingStore } from "../../../../stores/routingStore";

export class SignUpInstructorStore {
    @observable public email?: string;
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
            await AccountService.signUpInstructor(this.getDto());
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

    private getDto = (): SignUpInstructorDataDto => {
        return SignUpInstructorDataDto.fromJS({
            email: this.email,
            password: this.password,
        });
    };
}
