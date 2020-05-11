import { ConfirmationDetails } from "../../../components/modals/confirmationManager";
import { stores } from "../../../stores";
import { ConfirmationHandler } from "../../../components/modals/confirmationModal";
import { MouseEvent } from "react";

interface ConfirmationSettings<TResult> extends Omit<ConfirmationDetails, "actions"> {
    actions: Array<ConfirmationActionHandler<TResult>>;
}

interface ConfirmationActionHandler<TResult> extends Omit<ConfirmationHandler, "onClick"> {
    onClick: (e: MouseEvent, resolve: (result?: TResult) => void) => void;
}

export class ConfirmationsService {
    public static show<TResult>({ actions, ...rest }: ConfirmationSettings<TResult>): Promise<TResult> {
        return new Promise(resolve => {
            stores.confirmationManager.open({
                ...rest,
                actions: actions.map(a => ({
                    ...a,
                    onClick: e => a.onClick(e, resolve),
                })),
            });
        });
    }
}
