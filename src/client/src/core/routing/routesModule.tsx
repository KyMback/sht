import React from "react";
import { Switch, Route as HistoryRoute, Redirect } from "react-router-dom";
import { GuardProps } from "./guards";
import { routingStore } from "../../stores/routingStore";

interface Props {
    routes: Array<Route>;
}

export interface Route {
    component?: React.FC;
    path?: string;
    exact?: boolean;
    redirectTo?: string;
    guards?: Array<React.FC<GuardProps>>;
}

export const RoutesModule = ({ routes }: Props) => {
    return (
        <Switch>
            {routes.map(({ exact, path, component, redirectTo, guards }, index) => {
                let cmp = component;
                if (guards && !redirectTo) {
                    cmp = applyGuards(guards, component!);
                }

                return redirectTo
                    ? (
                        <HistoryRoute key={index} path={path} exact={exact}>
                            <Redirect to={{ pathname: redirectTo }}/>
                        </HistoryRoute>
                    )
                    : <HistoryRoute key={index} path={path} component={cmp} exact={exact}/>;
            })}
            <HistoryRoute><Redirect to={routingStore.basePath}/></HistoryRoute>
        </Switch>
    );
};

function applyGuards(guards: Array<React.FC<GuardProps>>, component: React.FC): React.FC {
    return guards.reduce((acc, Guard) => () => <Guard component={acc}/>, component);
}
