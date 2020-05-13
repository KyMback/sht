import { StartStudentTestConfirmationStore } from "./confirmations/startStudentTestConfirmationStore";
import { ConfirmationsService } from "../common/confirmations/confirmationsService";
import { StartStudentTestConfirmationBody } from "./confirmations/startStudentTestConfirmationBody";
import React from "react";

export class StudentTestSessionsConfirmationsService {
    public static openChooseVariantConfirmation(studentTestSessionId: string): Promise<string | undefined> {
        const store = new StartStudentTestConfirmationStore(studentTestSessionId);

        return ConfirmationsService.show<string | undefined>({
            body: <StartStudentTestConfirmationBody store={store} />,
            title: "StudentTestSession_StartTestModalTitle",
            actions: [
                {
                    color: "secondary",
                    title: "Cancel",
                    onClick: (_, resolve) => store.cancel(resolve),
                },
                {
                    color: "primary",
                    title: "StudentTestSession_StartTestModalButton",
                    onClick: store.submit,
                },
            ],
        });
    }
}
