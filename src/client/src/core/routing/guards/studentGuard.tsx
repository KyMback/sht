import { GuardProps } from "./index";
import { userContextStore } from "../../../stores/userContextStore";
import { Redirect } from "react-router-dom";
import React from "react";
import { UserType } from "../../../typings/dataContracts";

export const student = ({ component: Component }: GuardProps) => {
    return userContextStore.userType === UserType.Student
        ? <Component/>
        : <Redirect to={{ pathname: "/internal/instructor" }}/>;
};
