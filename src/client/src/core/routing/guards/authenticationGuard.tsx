import React from "react";
import { userContextStore } from "../../../stores/userContextStore";
import { Redirect } from "react-router-dom";
import { GuardProps } from "./index";

export const authenticated = ({ component: Component }: GuardProps) => {
    const v =  userContextStore.isAuthenticated;
    return v
        ? <Component/>
        : <Redirect to={{ pathname: "/login" }}/>
};
