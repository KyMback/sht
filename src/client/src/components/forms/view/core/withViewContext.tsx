import React from "react";
import { ViewContextProps, ViewContextWrapper } from "./viewContextWrapper";

export function withViewContext<TControlProps>(
    Control: React.FC<TControlProps>,
): React.FC<ViewContextProps & TControlProps> {
    return ({ mode, ...rest }) => {
        return (
            <ViewContextWrapper mode={mode}>
                <Control {...(rest as TControlProps)} />
            </ViewContextWrapper>
        );
    };
}
