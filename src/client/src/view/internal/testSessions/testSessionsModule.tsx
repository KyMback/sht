import { Route, RoutesModule } from "../../../core/routing/routesModule";
import React from "react";
import { TestSessionsList } from "./testSessionsList";
import { AddTestSession } from "./add/addTestSession";
import { TestSessionDashboard } from "./dashboard/testSessionDashboard";

const routes: Array<Route> = [
    {
        path: "/test-session",
        exact: true,
        redirectTo: "/test-session/list",
    },
    {
        path: "/test-session/list",
        component: TestSessionsList,
    },
    {
        path: "/test-session/add",
        component: AddTestSession,
    },
    {
        path: "/test-session/:id",
        component: TestSessionDashboard,
    },
];

export const TestSessionsModule = () => <RoutesModule routes={routes}/>;
