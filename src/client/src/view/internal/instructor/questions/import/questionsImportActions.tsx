import { ConfirmationsService } from "../../../../../services/common/confirmations/confirmationsService";
import React from "react";
import { QuestionsImportModal } from "./questionsImportModal";
import { QuestionsImportModalStore } from "./questionsImportModalStore";

export class QuestionsImportActions {
    public static openImportModal = async () => {
        const store = new QuestionsImportModalStore();

        return ConfirmationsService.show({
            title: "QuestionTemplatesImport",
            body: <QuestionsImportModal store={store} />,
            actions: [
                {
                    color: "secondary",
                    title: "Cancel",
                    onClick: (_, resolve) => resolve(),
                },
                {
                    color: "primary",
                    title: "Submit",
                    onClick: store.submit,
                },
            ],
        });
    };
}
