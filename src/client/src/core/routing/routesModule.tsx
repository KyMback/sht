import React from "react"
import { Switch, Route as HistoryRoute, RouteComponentProps, Redirect } from "react-router-dom"
import { GuardProps } from "./guards/authenticationGuard";

interface Props {
    routes: Array<Route>;
}

export interface Route {
    component?: React.ComponentType<RouteComponentProps<any>> | React.ComponentType<any>;
    render?: (props: RouteComponentProps<any>) => React.ReactNode;
    path?: string;
    exact?: boolean;
    redirectTo?: string;
    guards?: Array<React.FC<GuardProps>>;
}

export const RoutesModule = ({ routes }: Props) => {
    return (
        <Switch>
            {routes.map(({ exact, path, component, render, redirectTo, guards }, index) => {
                const target = redirectTo
                    ? <HistoryRoute key={index} path={path}><Redirect to={{ pathname: redirectTo }}/></HistoryRoute>
                    : <HistoryRoute key={index} path={path} component={component} exact={exact}/>;
                if (guards) {
                    const Guarded = applyGuards(guards, () => target);
                    return <Guarded/>
                }

                return target;
            })}
        </Switch>
    )
};

function applyGuards(guards: Array<React.FC<GuardProps>>, component: React.FC): React.FC {
    return guards.reduce((acc, guard) => () => guard({ component: acc }), component)
}
