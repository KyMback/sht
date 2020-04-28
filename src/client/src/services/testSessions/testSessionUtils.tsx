import { Local, LocalProps } from "../../core/localization/local";
import { TestSessionStates } from "../../typings/testSessionStates";
import React from "react";
import { localStore } from "../../stores/localStore";

interface TestSessionStateLocalProps extends Omit<LocalProps, "id"> {
    state: TestSessionStateType;
}

export type TestSessionStateType = typeof TestSessionStates[keyof typeof TestSessionStates];

export const TestSessionStateLocal = ({ state, ...rest }: TestSessionStateLocalProps) => {
    return <Local {...rest} id={getTestSessionStateKey(state)} />;
};

export function localizeTestSessionState(state: TestSessionStateType) {
    return localStore.getLocalizedMessage(getTestSessionStateKey(state));
}

function getTestSessionStateKey(state: TestSessionStateType) {
    return `TestSessionState_${state}`;
}
