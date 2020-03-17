import { AccountApi } from "../../../core/api/accountApi";
import { SignUpStudentDataDto, UserType } from "../../../typings/dataContracts";
import { action, observable } from "mobx";
import { routingStore } from "../../../stores/routingStore";
import { notifications } from "../../../components/notifications/notifications";
import { apiErrors, isExpected } from "../../../core/api/http/apiError";

export class SignUpStudentStore {
    @observable public email?: string;
    @observable public firstName?: string;
    @observable public lastName?: string;
    @observable public group?: string;
    @observable public password?: string;
    @observable public repeatPassword?: string;

    @action public setEmail = (value?: string) => (this.email = value);
    @action public setFirstName = (value?: string) => (this.firstName = value);
    @action public setLastName = (value?: string) => (this.lastName = value);
    @action public setGroup = (value?: string) => (this.group = value);
    @action public setPassword = (value?: string) => (this.password = value);
    @action public setRepeatPassword = (value?: string) => (this.repeatPassword = value);

    public repeatPasswordValidation = () => {
        return this.repeatPassword !== this.password ? "repeatPasswordNotEqual" : undefined;
    };

    public signUp = async () => {
        try {
            await AccountApi.signUp(
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
}
