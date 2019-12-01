import { Route, RoutesModule } from "../core/routing/routesModule";
import React from "react";
import { authenticated } from "../core/routing/guards/authenticationGuard";
import { InternalModule } from "./internal/internalModule";
import { anonymous } from "../core/routing/guards/anonymousGuard";
import { Login } from "./public/login/login";
import { SignUp } from "./public/signUp/signUp";

const routes: Array<Route> = [
    {
        path: "/internal",
        component: InternalModule,
        guards: [authenticated],
    },
    {
        path: "/login",
        component: Login,
        guards: [anonymous],
    },
    {
        path: "/signUp",
        component: SignUp,
        guards: [anonymous],
    },
    {
        path: "/",
        redirectTo: "/internal",
        exact: true,
    },
];

export const RootModule = () => <RoutesModule routes={routes}/>;
