import { Route, RoutesModule } from "../../../../core/routing/routesModule";
import React from "react";
import { TestVariantsListPage } from "./list/testVariantsListPage";
import { TestVariantDetails } from "./details/testVariantDetails";

const routes: Array<Route> = [
    {
        path: "/test-variants/list",
        component: TestVariantsListPage,
    },
    {
        path: "/test-variants/add",
        component: TestVariantDetails,
    },
    {
        path: "/test-variants/:id/details",
        component: TestVariantDetails,
    },
    {
        path: "/test-variants",
        redirectTo: "/test-variants/list",
    },
];

export const TestVariantsModule = () => <RoutesModule routes={routes} />;
