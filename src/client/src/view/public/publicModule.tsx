import { Route, RoutesModule } from "../../core/routing/routesModule";
import React from "react";
import { Login } from "./login/login";
import { SignUpPage } from "./signUp/signUpPage";

const routes: Array<Route> = [
    {
        path: "/",
        exact: true,
        redirectTo: "/login",
    },
    {
        path: "/login",
        component: Login,
    },
    {
        path: "/sign-up",
        component: SignUpPage,
    },
];

export const PublicModule = () => <RoutesModule routes={routes} />;
