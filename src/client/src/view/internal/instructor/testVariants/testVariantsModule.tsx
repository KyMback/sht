import { Route, RoutesModule } from "../../../../core/routing/routesModule";
import React from "react";
import { TestVariantsListPage } from "./list/testVariantsListPage";

const routes: Array<Route> = [
    {
        path: "/test-variants/list",
        component: TestVariantsListPage,
    },
    {
        path: "/test-variants",
        redirectTo: "/test-variants/list",
    },
];

export const TestVariantsModule = () => <RoutesModule routes={routes} />;
