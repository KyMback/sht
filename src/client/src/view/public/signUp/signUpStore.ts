import { AccountApi } from "../../../core/api/accountApi";
import { SignUpDataDto, UserType } from "../../../typings/dataContracts";
import { action, observable } from "mobx";
import { routingStore } from "../../../stores/routingStore";
import { notifications } from "../../../components/notifications/notifications";
import { apiErrors, isExpected } from "../../../core/api/http/apiError";

export class SignUpStore {
    @observable public login?: string;
    @observable public password?: string;
    @observable public repeatPassword?: string;

    @action public setLogin = (value?: string) => this.login = value;
    @action public setPassword = (value?: string) => this.password = value;
    @action public setRepeatPassword = (value?: string) => this.repeatPassword = value;

    public repeatPasswordValidation = () => {
        return this.repeatPassword !== this.password ? "repeatPasswordNotEqual" : undefined;
    };

    public signUp = async () => {
        try {
            await AccountApi.signUp(SignUpDataDto.fromJS({
                login: this.login,
                password: this.password,
                userType: UserType.Student,
            }));
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
}
