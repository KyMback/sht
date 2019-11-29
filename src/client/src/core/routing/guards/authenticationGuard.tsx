import React from "react";
import { contextStore } from "../../../stores/contextStore";
import { Redirect } from "react-router-dom";

export interface GuardProps {
    component: React.FC;
}

export const authenticated = ({ component: Component }: GuardProps) => {
    return contextStore.isAuthenticated
        ? <Component/>
        : <Redirect to={{ pathname: "/login" }}/>
};
