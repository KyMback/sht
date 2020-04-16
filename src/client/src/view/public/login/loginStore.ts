import { observable } from "mobx";
import { AccountService } from "../../../services/accountService";
import { SignInDataDto, UserType } from "../../../typings/dataContracts";
import { userContextStore } from "../../../stores/userContextStore";
import { routingStore } from "../../../stores/routingStore";
import { notifications } from "../../../components/notifications/notifications";
import { apiErrors, isExpected } from "../../../core/api/http/apiError";

export class LoginStore {
    @observable public login?: string;
    @observable public password?: string;

    public signIn = async () => {
        try {
            const result = await AccountService.signIn(
                SignInDataDto.fromJS({
                    login: this.login,
                    password: this.password,
                }),
            );
            if (result.succeeded) {
                await userContextStore.loadContext();
                await routingStore.gotoBase();
                if (userContextStore.userType === UserType.Student) {
                    notifications.success("SuccessfullySignIn");
                }
            } else {
                notifications.error("InvalidLoginOrPassword");
            }
        } catch (e) {
            if (isExpected(e, apiErrors.notConfirmedEmail)) {
                notifications.errorCode(apiErrors.notConfirmedEmail);
            } else {
                throw e;
            }
        }
    };
}
