import { Route, RoutesModule } from "../../../../core/routing/routesModule";
import React from "react";
import { StudentTestSessions } from "./studentTestSessions";

const routes: Array<Route> = [
    {
        path: "/test-session",
        exact: true,
        redirectTo: "/test-session/list",
    },
    {
        path: "/test-session/list",
        component: StudentTestSessions,
    },
    // {
    //     path: "/test-session/:id",
    //     component: TestSessionDashboard,
    // },
];

export const TestSessionsModule = () => <RoutesModule routes={routes}/>;
