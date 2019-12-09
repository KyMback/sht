import React, { useState } from "react";
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
import { LoadingAnimationWrapper } from "./components/layouts/loading/loadingAnimationWrapper";
import { NotificationsContainer } from "./components/notifications/notifications";
import { ApiErrorHandler } from "./core/api/http/apiErrorHandler";

export const App = observer(() => {
    const [isContextLoaded, setIsContextLoaded] = useState<boolean>(false);
    useAsyncEffect(async () => {
        await userContextStore.loadContext();
        setIsContextLoaded(true);
    }, []);

    return (
        <>
            <IntlProvider locale={localStore.language} messages={localStore.messages}>
                <Router history={routingStore.history}>
                    <ApiErrorHandler>
                        <MainLayout>
                            {isContextLoaded && <RootModule/>}
                        </MainLayout>
                    </ApiErrorHandler>
                </Router>
                {NotificationsContainer}
            </IntlProvider>
            <LoadingAnimationWrapper/>
        </>
    );
});

