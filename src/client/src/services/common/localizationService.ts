import { AccountService } from "../accountService";

export class LocalizationService {
    public static setLocalization = async (localization: string) => {
        await AccountService.setCulture(localization);
        await AccountService.updateUserContext();
    };
}
