import { action, computed, observable } from "mobx";
import { createContext } from "react";

export enum ViewModeType {
    View = "View",
    Edit = "Edit",
}

export interface ViewContextOptions {
    defaultViewMode?: ViewModeType;
}

export class ViewContextStore {
    @observable public viewModeType: ViewModeType;

    @computed
    public get isEditMode(): boolean {
        return this.viewModeType === ViewModeType.Edit;
    }

    @computed
    public get isViewMode(): boolean {
        return this.viewModeType === ViewModeType.View;
    }

    @action public setViewMode = (value?: ViewModeType) => (this.viewModeType = value || this.viewModeType);
    @action public viewMode = () => this.setViewMode(ViewModeType.View);
    @action public editMode = () => this.setViewMode(ViewModeType.Edit);

    constructor(options?: ViewContextOptions) {
        this.viewModeType = (options && options.defaultViewMode) || ViewModeType.View;
    }
}

export const ViewContext = createContext<ViewContextStore | undefined>(undefined);
