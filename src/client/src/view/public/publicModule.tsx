import { Route, RoutesModule } from "../../core/routing/routesModule";
import React from "react";
import { Login } from "./login/login";

const routes: Array<Route> = [
    {
        path: "/login",
        component: Login,
    },
    {
        path: "/",
        redirectTo: "/login",
        exact: true,
    },
];

export const PublicModule = () => <RoutesModule routes={routes}/>;
