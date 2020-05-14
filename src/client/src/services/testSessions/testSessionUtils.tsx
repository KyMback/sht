import { Local, LocalProps } from "../../core/localization/local";
import React from "react";
import { localStore } from "../../stores/localStore";
import { TestSessionState } from "../../typings/testSessionState";

interface TestSessionStateLocalProps extends Omit<LocalProps, "id"> {
    state: TestSessionStateType;
}

export type TestSessionStateType = typeof TestSessionState[keyof typeof TestSessionState];

export const TestSessionStateLocal = ({ state, ...rest }: TestSessionStateLocalProps) => {
    return <Local {...rest} id={getTestSessionStateKey(state)} />;
};

export function localizeTestSessionState(state: TestSessionStateType) {
    return localStore.getLocalizedMessage(getTestSessionStateKey(state));
}

function getTestSessionStateKey(state: TestSessionStateType) {
    return `TestSessionState_${state}`;
}
