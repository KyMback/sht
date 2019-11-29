import { computed, observable } from "mobx";
import en from "./../static/localizations/en.json";
import { Dictionary } from "../typings/customTypings";

const messages: Dictionary = {
    "en": en,
};

class LocalStore {
    @observable public language: string;

    @computed
    public get messages(): any {
        return messages[this.language];
    }

    constructor() {
        this.language = "en";
    }
}

export const localStore = new LocalStore();
