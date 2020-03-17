import { Route, RoutesModule } from "../core/routing/routesModule";
import React from "react";
import { SignOut } from "./public/signOut/signOut";
import { EmailConfirmationPage } from "./public/emailConfirmation/emailConfirmationPage";
import { InternalModule } from "./internal/internalModule";
import { userContextStore } from "../stores/userContextStore";
import { PublicModule } from "./public/publicModule";

const routes: Array<Route> = [
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
        component: () => (userContextStore.isAuthenticated ? <InternalModule /> : <PublicModule />),
    },
];

export const RootModule = () => <RoutesModule routes={routes} />;
