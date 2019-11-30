import { Route, RoutesModule } from "../core/routing/routesModule";
import React from "react";
import { authenticated } from "../core/routing/guards/authenticationGuard";
import { InternalModule } from "./internal/internalModule";
import { anonymous } from "../core/routing/guards/anonymousGuard";
import { Login } from "./public/login/login";

const routes: Array<Route> = [
    {
        path: "/",
        component: InternalModule,
        exact: true,
        guards: [authenticated],
    },
    {
        path: "/login",
        component: Login,
        guards: [anonymous]
    },
];

export const RootModule = () => <RoutesModule routes={routes}/>;
