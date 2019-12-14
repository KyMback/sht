import { Route, RoutesModule } from "../../../core/routing/routesModule";
import React from "react";
import { TestSessionsModule } from "./testSessions/testSessionsModule";
import { TestVariantsModule } from "./testVariants/testVariantsModule";

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
    {
        path: "/test-variants",
        component: TestVariantsModule,
    },
    {
        path: "/questions",
        component: () => <></>,
    },
];

export const InstructorModule = () => <RoutesModule routes={routes} />;
