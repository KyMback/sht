import React from "react";
import "./styles/styles.scss";
import { MainLayout } from "./components/layouts/mainLayout";
import { Router } from "react-router-dom";
import { routingStore } from "./stores/routingStore";
import { RootModule } from "./view/rootModule";
import { useAsyncEffect } from "use-async-effect";
import { userContextStore } from "./stores/userContextStore";
import { observer } from "mobx-react-lite";
import { IntlProvider } from "react-intl";
import { localStore } from "./stores/localStore";

export const App = observer(() => {
    useAsyncEffect(userContextStore.loadContext, []);

    return (
        <IntlProvider locale={localStore.language} messages={localStore.messages}>
            <Router history={routingStore.history}>
                <MainLayout>
                    <RootModule/>
                </MainLayout>
            </Router>
        </IntlProvider>
    );
});
