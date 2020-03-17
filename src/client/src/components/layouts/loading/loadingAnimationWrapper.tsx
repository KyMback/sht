import { observer } from "mobx-react-lite";
import React from "react";
import { Loading } from "./loading";
import { rootViewStore } from "../../../stores/rootViewStore";

export const LoadingAnimationWrapper = observer(() => {
    return (
        <div style={{ display: rootViewStore.loadingIsShown ? "block" : "none" }} className="loading-animation-wrapper">
            <Loading className="loading-animation" />
        </div>
    );
});
