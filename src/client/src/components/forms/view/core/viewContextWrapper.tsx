import { observer, useLocalStore } from "mobx-react-lite";
import React, { PropsWithChildren, useEffect } from "react";
import { ViewContext, ViewContextStore, ViewModeType } from "./viewContextStore";

export interface ViewContextProps {
    mode: ViewModeType;
}

export const ViewContextWrapper = observer(({ mode, children }: PropsWithChildren<ViewContextProps>) => {
    const store = useLocalStore(() => new ViewContextStore({ defaultViewMode: mode }));
    useEffect(() => {
        store.setViewMode(mode);
    }, [mode, store]);

    return <ViewContext.Provider value={store}>{children}</ViewContext.Provider>;
});