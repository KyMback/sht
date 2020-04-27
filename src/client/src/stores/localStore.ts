import { action, computed, observable } from "mobx";
import en from "./../static/localizations/en.json";
import ru from "./../static/localizations/ru.json";
import { Dictionary } from "../typings/customTypings";
import { IntlShape, createIntl } from "react-intl";

const messages: Dictionary = {
    en: en,
    ru: ru,
};

const defaultLanguage = "ru";

class LocalStore {
    public readonly supportedLanguages: Array<LanguageItem> = [
        {
            abbr: "ru",
            name: "Русский",
        },
        {
            abbr: "en",
            name: "English",
        },
    ];

    @observable public language: string;
    @observable public intlShape: IntlShape;

    @computed
    public get messages(): any {
        return messages[this.language];
    }

    constructor() {
        this.language = defaultLanguage;
        this.intlShape = this.createIntl();
    }

    @action
    public setLanguage = (value: string = defaultLanguage) => {
        if (value === this.language) {
            return;
        }

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

interface LanguageItem {
    abbr: string;
    name: string;
}

export const localStore = new LocalStore();
