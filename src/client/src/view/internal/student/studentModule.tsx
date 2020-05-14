import { Route, RoutesModule } from "../../../core/routing/routesModule";
import React from "react";
import { TestSessionsModule } from "./testSessions/testSessionsModule";
import { StudentProfilePage } from "./profile/studentProfilePage";
import { AnswersRatingsModule } from "./answersRatings/answersRatingsModule";

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
        path: "/answers-ratings",
        component: AnswersRatingsModule,
    },
    {
        path: "/profile",
        component: StudentProfilePage,
    },
];

export const StudentModule = () => <RoutesModule routes={routes} />;
