import { Route, RoutesModule } from "../../../../core/routing/routesModule";
import React from "react";
import { TestSessionsList } from "./testSessionsList";
import { TestSessionEditDetails } from "./details/testSessionEditDetails";
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
        component: TestSessionEditDetails,
    },
    {
        path: "/test-session/edit/:id",
        component: TestSessionEditDetails,
    },
    {
        path: "/test-session/dashboard/:id",
        component: TestSessionDashboard,
    },
];

export const TestSessionsModule = () => <RoutesModule routes={routes} />;
