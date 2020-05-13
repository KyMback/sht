import { Route, RoutesModule } from "../../../../../core/routing/routesModule";
import React, { createContext, useEffect } from "react";
import { StudentTestSessionQuestionsList } from "./list/studentTestSessionQuestionsList";
import { observer, useLocalStore } from "mobx-react-lite";
import { useParams } from "react-router-dom";
import { StudentQuestionsContextStore } from "./infrasturcture/studentQuestionsContextStore";
import { BaseQuestionPage } from "./infrasturcture/baseQuestionPage";
import { routingStore } from "../../../../../stores/routingStore";
import { StudentTestSessionState } from "../../../../../typings/studentTestSessionState";
import { useStoreLifeCycle } from "../../../../../core/hooks/useStoreLifeCycle";

const routes: Array<Route> = [
    {
        path: "/test-session/:sessionId/questions/list",
        component: StudentTestSessionQuestionsList,
    },
    {
        path: "/test-session/:sessionId/questions/:id",
        exact: true,
        component: BaseQuestionPage,
    },
    {
        path: "/test-session/:sessionId/questions",
        redirectTo: "/test-session/:sessionId/questions/list",
    },
];

export const StudentQuestionsContext = createContext<StudentQuestionsContextStore | undefined>(undefined);

interface Params {
    sessionId: string;
}

export const StudentQuestionsModule = observer(() => {
    const params = useParams<Params>();
    const store = useLocalStore(() => new StudentQuestionsContextStore(params.sessionId));
    useStoreLifeCycle(store);
    useEffect(() => {
        if (store.sessionState && store.sessionState !== StudentTestSessionState.Started) {
            routingStore.goto(`/test-session/${store.sessionId}`);
        }
    }, [store.sessionId, store.sessionState]);

    return (
        <StudentQuestionsContext.Provider value={store}>
            {store.initialized && <RoutesModule routes={routes} />}
        </StudentQuestionsContext.Provider>
    );
});
