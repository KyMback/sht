import { Route, RoutesModule } from "../../../../core/routing/routesModule";
import React from "react";
import { QuestionsListPage } from "./questionsListPage";
import { QuestionEditPage } from "./details/edit/questionEditPage";
import { QuestionViewPage } from "./details/view/questionViewPage";

const routes: Array<Route> = [
    {
        path: "/questions",
        exact: true,
        redirectTo: "/questions/list",
    },
    {
        path: "/questions/list",
        component: QuestionsListPage,
    },
    {
        path: "/questions/add",
        component: QuestionEditPage,
    },
    {
        path: "/questions/:id/edit",
        component: QuestionEditPage,
    },
    {
        path: "/questions/:id",
        component: QuestionViewPage,
    },
];

export const QuestionsModule = () => <RoutesModule routes={routes} />;
