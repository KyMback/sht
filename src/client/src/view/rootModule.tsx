import { Route, RoutesModule } from "../core/routing/routesModule";
import React from "react";
import { authenticated } from "../core/routing/guards/authenticationGuard";
import { anonymous } from "../core/routing/guards/anonymousGuard";
import { Login } from "./public/login/login";
import { SignUp } from "./public/signUp/signUp";
import { SignOut } from "./public/signOut/signOut";
import { TestSessionsDashboard } from "./internal/testSessionsDashboard/testSessionsDashboard";

const routes: Array<Route> = [
    {
        path: "/dashboard",
        component: () => <></>,
        exact: true,
        guards: [authenticated],
    },
    {
        path: "/test-sessions",
        component: TestSessionsDashboard,
        exact: true,
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
        path: "/signOut",
        component: SignOut,
    },
    {
        path: "/",
        redirectTo: "/dashboard",
        exact: true,
    },
];

export const RootModule = () => <RoutesModule routes={routes}/>;
