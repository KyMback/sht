import { Route, RoutesModule } from "../../../core/routing/routesModule";
import React from "react";
import { TestSessionsModule } from "./testSessions/testSessionsModule";
import { TestVariantsModule } from "./testVariants/testVariantsModule";
import { InstructorProfilePage } from "./profile/instructorProfilePage";
import { QuestionsListPage } from "./questions/questionsListPage";

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
        component: QuestionsListPage,
    },
    {
        path: "/profile",
        component: InstructorProfilePage,
    },
];

export const InstructorModule = () => <RoutesModule routes={routes} />;
