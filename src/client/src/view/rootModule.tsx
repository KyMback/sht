import { Route, RoutesModule } from "../core/routing/routesModule";
import React from "react";
import { authenticated } from "../core/routing/guards/authenticationGuard";
import { anonymous } from "../core/routing/guards/anonymousGuard";
import { Login } from "./public/login/login";
import { SignUpStudent } from "./public/signUpStudent/signUpStudent";
import { SignOut } from "./public/signOut/signOut";
import { TestSessionsModule } from "./internal/testSessions/testSessionsModule";
import { EmailConfirmationPage } from "./public/emailConfirmation/emailConfirmationPage";

const routes: Array<Route> = [
    {
        path: "/dashboard",
        component: () => <></>,
        exact: true,
        guards: [authenticated],
    },
    {
        path: "/test-session",
        component: TestSessionsModule,
        guards: [authenticated],
    },
    {
        path: "/login",
        component: Login,
        guards: [anonymous],
    },
    {
        path: "/signUp",
        component: SignUpStudent,
        guards: [anonymous],
    },
    {
        path: "/signOut",
        component: SignOut,
    },
    {
        path: "/email-confirmation",
        component: EmailConfirmationPage,
    },
    {
        path: "/",
        redirectTo: "/dashboard",
        exact: true,
    },
];

export const RootModule = () => <RoutesModule routes={routes}/>;
