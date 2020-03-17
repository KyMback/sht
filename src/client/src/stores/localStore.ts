import { action, computed, observable } from "mobx";
import en from "./../static/localizations/en.json";
import { Dictionary } from "../typings/customTypings";
import { IntlShape, createIntl } from "react-intl";

const messages: Dictionary = {
    en: en,
};

class LocalStore {
    @observable private language: string;
    @observable public intlShape: IntlShape;

    @computed
    public get messages(): any {
        return messages[this.language];
    }

    constructor() {
        this.language = "en";
        this.intlShape = this.createIntl();
    }

    @action
    public setLanguage = (value: string) => {
        this.language = value;
        this.intlShape = this.createIntl();
    };

    public getLocalizedMessage = (key: string): string => {
        return this.intlShape.formatMessage({
            id: key,
        });
    };

    private createIntl = (): IntlShape => {
        return createIntl({
            messages: this.messages,
            locale: this.language,
        });
    };
}

export const localStore = new LocalStore();
