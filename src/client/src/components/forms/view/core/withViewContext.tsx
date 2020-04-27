import React, { useEffect } from "react";
import { ViewModeType, ViewContext, ViewContextStore } from "./viewContextStore";
import { useLocalStore } from "mobx-react-lite";

export interface ViewContextProps {
    mode: ViewModeType;
}

export function withViewContext<TControlProps>(
    Control: React.FC<ViewContextProps & TControlProps>,
): React.FC<ViewContextProps & Partial<TControlProps>> {
    return ({ mode, ...rest }) => {
        const store = useLocalStore(() => new ViewContextStore({ defaultViewMode: mode }));
        useEffect(() => {
            store.setViewMode(mode);
        }, [mode, store]);

        return (
            <ViewContext.Provider value={store}>
                <Control {...((rest as unknown) as TControlProps)} mode={store.viewModeType} />
            </ViewContext.Provider>
        );
    };
}
