import { GuardProps } from "./index";
import { userContextStore } from "../../../stores/userContextStore";
import { Redirect } from "react-router-dom";
import React from "react";

export const anonymous = ({ component: Component }: GuardProps) => {
    return !userContextStore.isAuthenticated
        ? <Component/>
        : <Redirect to={{ pathname: "/internal" }}/>
};
