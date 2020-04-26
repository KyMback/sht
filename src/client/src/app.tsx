import React, { useState } from "react";
import "./styles/styles.scss";
import { MainLayout } from "./view/common/mainLayout";
import { Router } from "react-router-dom";
import { routingStore } from "./stores/routingStore";
import { RootModule } from "./view/rootModule";
import { useAsyncEffect } from "use-async-effect";
import { observer } from "mobx-react-lite";
import { RawIntlProvider } from "react-intl";
import { localStore } from "./stores/localStore";
import { LoadingAnimationWrapper } from "./components/layouts/loading/loadingAnimationWrapper";
import { NotificationsContainer } from "./components/notifications/notifications";
import { ApiErrorHandler } from "./core/api/http/apiErrorHandler";
import { ConfirmationContainer } from "./components/modals/confirmationContainer";
import { stores } from "./stores";
import { AccountService } from "./services/accountService";

export const App = observer(() => {
    const [isContextLoaded, setIsContextLoaded] = useState<boolean>(false);
    useAsyncEffect(async () => {
        await AccountService.updateUserContext();
        setIsContextLoaded(true);
    }, []);

    return (
        <RawIntlProvider value={localStore.intlShape}>
            <Router history={routingStore.history}>
                <ApiErrorHandler>
                    <MainLayout>{isContextLoaded && <RootModule />}</MainLayout>
                </ApiErrorHandler>
            </Router>
            <ConfirmationContainer store={stores.confirmationManager} />
            <NotificationsContainer />
            <LoadingAnimationWrapper />
        </RawIntlProvider>
    );
});
