import { ConfirmationDetails } from "../../../components/modals/confirmationManager";
import { stores } from "../../../stores";

export class ConfirmationsService {
    public static show = (details: ConfirmationDetails) => {
        stores.confirmationManager.open(details);
    };
}
