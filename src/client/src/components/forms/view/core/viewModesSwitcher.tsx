import React, { useContext } from "react";
import { ViewContext } from "./viewContextStore";
import { Observer } from "mobx-react-lite";

interface Props<TControlProps> {
    props: TControlProps;
    edit: React.FC<TControlProps>;
    view: React.FC<TControlProps>;
}

export function ViewModesSwitcher<TControlProps>({ edit: Edit, props, view: View }: Props<TControlProps>) {
    const context = useContext(ViewContext);
    return <Observer>{() => (context && context.isViewMode ? <View {...props} /> : <Edit {...props} />)}</Observer>;
}
