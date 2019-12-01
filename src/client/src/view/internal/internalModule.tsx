import { Route, RoutesModule } from "../../core/routing/routesModule";
import React from "react";
import { student } from "../../core/routing/guards/studentGuard";
import { instructor } from "../../core/routing/guards/instructorGuard";

const routes: Array<Route> = [
    {
        path: "/internal",
        exact: true,
        redirectTo: "/internal/student",
    },
    {
        path: "/internal/student",
        component: () => <></>,
        guards: [student],
    },
    {
        path: "/internal/instructor",
        component: () => <></>,
        guards: [instructor],
    },
];

export const InternalModule = () => <RoutesModule routes={routes}/>;
