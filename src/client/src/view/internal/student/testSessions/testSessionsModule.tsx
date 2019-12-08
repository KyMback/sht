import { Route, RoutesModule } from "../../../../core/routing/routesModule";
import React from "react";
import { StudentTestSessions } from "./studentTestSessions";
import { StudentTestSessionDashboard } from "./dashboard/studentTestSessionDashboard";

const routes: Array<Route> = [
    {
        path: "/test-session/list",
        component: StudentTestSessions,
    },
    {
        path: "/test-session/:id",
        component: StudentTestSessionDashboard,
    },
    {
        path: "/test-session",
        redirectTo: "/test-session/list",
    },
];

export const TestSessionsModule = () => <RoutesModule routes={routes}/>;
