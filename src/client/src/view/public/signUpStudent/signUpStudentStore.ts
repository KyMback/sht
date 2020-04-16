import { AccountService } from "../../../services/accountService";
import { SignUpStudentDataDto, UserType } from "../../../typings/dataContracts";
import { computed, observable } from "mobx";
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
}
