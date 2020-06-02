import { observable, runInAction } from "mobx";
import { QuestionListItem, QuestionsActionsService } from "../../../../services/questions/questionsActionsService";
import { AsyncInitializable } from "../../../../typings/customTypings";
import { QuestionsImportActions } from "./import/questionsImportActions";

export class QuestionsListPageStore implements AsyncInitializable {
    @observable items: Array<QuestionListItem> = [];

    public init = async (): Promise<void> => {
        await this.loadData();
    };

    private loadData = async () => {
        const result = await QuestionsActionsService.getListItems(1, 100);
        runInAction(() => {
            this.items = result.items;
        });
    };

    public importData = async () => {
        if (await QuestionsImportActions.openImportModal()) {
            await this.loadData();
        }
    };
}
