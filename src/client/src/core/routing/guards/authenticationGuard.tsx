import React from "react";
import { userContextStore } from "../../../stores/userContextStore";
import { Redirect } from "react-router-dom";

export interface GuardProps {
    component: React.FC;
}

export const authenticated = ({ component: Component }: GuardProps) => {
    return userContextStore.isAuthenticated
        ? <Component/>
        : <Redirect to={{ pathname: "/login" }}/>
};
