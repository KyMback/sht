import { Route, RoutesModule } from "../../core/routing/routesModule";
import React from "react";
import { userContextStore } from "../../stores/userContextStore";
import { StudentModule } from "./student/studentModule";
import { InstructorModule } from "./instructor/instructorModule";

const routes: Array<Route> = [
    {
        path: "/",
        component: () => (userContextStore.isInstructor ? <InstructorModule /> : <StudentModule />),
    },
];

export const InternalModule = () => <RoutesModule routes={routes} />;
