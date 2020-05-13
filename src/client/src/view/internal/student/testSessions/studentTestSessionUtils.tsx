import { Local, LocalProps } from "../../../../core/localization/local";
import { localStore } from "../../../../stores/localStore";
import React from "react";
import { StudentTestSessionState } from "../../../../typings/studentTestSessionState";

interface StudentTestSessionStateLocalProps extends Omit<LocalProps, "id"> {
    state: StudentTestSessionStateType;
}

export type StudentTestSessionStateType = typeof StudentTestSessionState[keyof typeof StudentTestSessionState];

export const StudentTestSessionStateLocal = ({ state, ...rest }: StudentTestSessionStateLocalProps) => {
    return <Local {...rest} id={getStudentTestSessionStateKey(state)} />;
};

export function localizeStudentTestSessionState(state: StudentTestSessionStateType) {
    return localStore.getLocalizedMessage(getStudentTestSessionStateKey(state));
}

function getStudentTestSessionStateKey(state: StudentTestSessionStateType) {
    return `StudentTestSessionState_${state}`;
}
