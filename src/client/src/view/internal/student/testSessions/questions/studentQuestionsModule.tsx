import { Route, RoutesModule } from "../../../../../core/routing/routesModule";
import React, { createContext, useEffect } from "react";
import { StudentTestSessionQuestionsList } from "./list/studentTestSessionQuestionsList";
import { observer, useLocalStore } from "mobx-react-lite";
import { useParams } from "react-router-dom";
import { StudentQuestionsContextStore } from "./infrasturcture/studentQuestionsContextStore";
import { BaseQuestionPage } from "./infrasturcture/baseQuestionPage";
import useAsyncEffect from "use-async-effect";
import { studentTestSessionStates } from "../dashboard/stateTransition/studentTestSessionStates";
import { routingStore } from "../../../../../stores/routingStore";

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

export const studentQuestionsContext = createContext<StudentQuestionsContextStore | undefined>(undefined);

interface Params {
    sessionId: string;
}

export const StudentQuestionsModule = observer(() => {
    const params = useParams<Params>();
    const store = useLocalStore(() => new StudentQuestionsContextStore(params.sessionId));
    useAsyncEffect(store.loadData, [params.sessionId]);
    useEffect(() => {
        if (store.sessionState && store.sessionState !== studentTestSessionStates.started) {
            routingStore.goto(`/test-session/${store.sessionId}`);
        }
    }, [store.sessionId, store.sessionState]);

    return (
        <studentQuestionsContext.Provider value={store}>
            {store.isDataLoaded && <RoutesModule routes={routes}/>}
        </studentQuestionsContext.Provider>
    );
});
