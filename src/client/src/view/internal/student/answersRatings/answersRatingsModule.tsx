import { Route, RoutesModule } from "../../../../core/routing/routesModule";
import React from "react";
import { AnswersRatingsList } from "./list/answersRaitingsList";
import { AnswersRatingsDetails } from "./details/answersRatingsDetails";

const routes: Array<Route> = [
    {
        path: "/answers-ratings/list",
        component: AnswersRatingsList,
    },
    {
        path: "/answers-ratings/:id",
        component: AnswersRatingsDetails,
    },
    {
        path: "/answers-ratings",
        redirectTo: "/answers-ratings/list",
    },
];

export const AnswersRatingsModule = () => <RoutesModule routes={routes} />;
