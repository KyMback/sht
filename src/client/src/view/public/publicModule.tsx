import { Route, RoutesModule } from "../../core/routing/routesModule";
import React from "react";
import { Login } from "./login/login";
import { SignUpStudent } from "./signUpStudent/signUpStudent";

const routes: Array<Route> = [
    {
        path: "/",
        exact: true,
        redirectTo: "/login"
    },
    {
        path: "/login",
        component: Login,
    },
    {
        path: "/signUp",
        component: SignUpStudent,
    },
];

export const PublicModule = () => <RoutesModule routes={routes}/>;
