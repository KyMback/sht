import React, { useMemo } from "react";
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
    const renderedRoutes = useMemo(() => {
        const result = routes.map(({ exact, path, component, redirectTo, guards }, index) => {
            let cmp = component;
            if (guards && !redirectTo) {
                cmp = applyGuards(guards, component!);
            }

            return redirectTo
                ? <Redirect key={index} from={path} to={{ pathname: redirectTo }} exact={exact}/>
                : <HistoryRoute key={index} path={path} component={cmp} exact={exact}/>;
        });
        result.push(<Redirect key={routingStore.basePath} to={routingStore.basePath}/>);

        return result;
    }, [routes]);

    return (
        <Switch>
            {renderedRoutes}
        </Switch>
    );
};

function applyGuards(guards: Array<React.FC<GuardProps>>, component: React.FC): React.FC {
    return guards.reduce((acc, Guard) => () => <Guard component={acc}/>, component);
}
