import { observable } from "mobx";
import { AccountService } from "../../../services/accountService";
import { SignInDataDto } from "../../../typings/dataContracts";
import { routingStore } from "../../../stores/routingStore";
import { notifications } from "../../../components/notifications/notifications";
import { apiErrors, isExpected, LocalError } from "../../../core/api/http/apiError";
import React from "react";
import { LinkButton } from "../../../components/buttons/linkButton";

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
                await AccountService.updateUserContext();
                await routingStore.gotoBase();
            } else {
                notifications.error("InvalidLoginOrPassword");
            }
        } catch (e) {
            if (isExpected(e, apiErrors.notConfirmedEmail)) {
                this.showNotConfirmedEmailError();
            } else {
                throw e;
            }
        }
    };

    private showNotConfirmedEmailError = () => {
        notifications.error(
            <div>
                <LocalError errorCode={apiErrors.notConfirmedEmail} />
                <LinkButton
                    className="text-info"
                    onClick={async () => {
                        await AccountService.resendEmailConfirmation(this.login!);
                        notifications.success("ResendEmailConfirmationSuccess");
                    }}
                    title="ResendEmailConfirmation"
                />
            </div>,
        );
    };
}
