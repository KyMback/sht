import { Route, RoutesModule } from "../../../core/routing/routesModule";
import React from "react";
import { TestSessionsDashboard } from "./testSessionsDashboard";
import { AddTestSession } from "./add/addTestSession";

const routes: Array<Route> = [
    {
        path: "/test-sessions",
        exact: true,
        redirectTo: "/test-sessions/dashboard",
    },
    {
        path: "/test-sessions/dashboard",
        component: TestSessionsDashboard,
    },
    {
        path: "/test-sessions/add",
        component: AddTestSession,
    },
];

export const TestSessionsModule = () => <RoutesModule routes={routes}/>;
