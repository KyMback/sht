import { Route, RoutesModule } from "../core/routing/routesModule";
import React from "react";
import { PublicModule } from "./public/publicModule";

const routes: Array<Route> = [
    {
        path: "/",
        component: PublicModule,
    }
];

export const RootModule = () => <RoutesModule routes={routes}/>;
