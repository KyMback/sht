import { computed, observable } from "mobx";
import { KeyOrJSX } from "../../typings/customTypings";
import { ConfirmationHandler } from "./confirmationModal";

export interface ConfirmationDetails {
    body: KeyOrJSX;
    title: KeyOrJSX;
    actions: Array<ConfirmationHandler>;
}

export class ConfirmationManager {
    @observable public details?: ConfirmationDetails;

    @computed
    public get isOpen(): boolean {
        return !!this.details;
    }

    public hide = () => {
        this.details = undefined;
    };

    public open = (details: ConfirmationDetails) => {
        this.details = details;
    };
}
