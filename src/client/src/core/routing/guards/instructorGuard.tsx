import { GuardProps } from "./index";
import { userContextStore } from "../../../stores/userContextStore";
import { UserType } from "../../../typings/dataContracts";
import { Redirect } from "react-router-dom";
import React from "react";

export const instructor = ({ component: Component }: GuardProps) => {
    return userContextStore.userType === UserType.Instructor
        ? <Component/>
        : <Redirect to={{ pathname: "/dashboard/student" }}/>;
};
