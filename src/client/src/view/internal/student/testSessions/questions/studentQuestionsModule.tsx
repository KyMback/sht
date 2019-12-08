import { Route, RoutesModule } from "../../../../../core/routing/routesModule";
import React from "react";
import { StudentTestSessionQuestionsList } from "./list/studentTestSessionQuestionsList";

const routes: Array<Route> = [
    {
        path: "/test-session/:sessionId/questions/list",
        component: StudentTestSessionQuestionsList,
    },
    {
        path: "/test-session/:sessionId/questions",
        redirectTo: "/test-session/:sessionId/questions/list",
    },
];

export const StudentQuestionsModule = () => <RoutesModule routes={routes}/>;
