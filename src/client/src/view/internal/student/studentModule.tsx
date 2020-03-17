import { Route, RoutesModule } from "../../../core/routing/routesModule";
import React from "react";
import { TestSessionsModule } from "./testSessions/testSessionsModule";

const routes: Array<Route> = [
    {
        path: "/",
        exact: true,
        redirectTo: "/test-session",
    },
    {
        path: "/test-session",
        component: TestSessionsModule,
    },
];

export const StudentModule = () => <RoutesModule routes={routes} />;
