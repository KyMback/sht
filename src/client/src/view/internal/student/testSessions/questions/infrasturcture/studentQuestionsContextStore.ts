import { observable, runInAction } from "mobx";
import { Dictionary } from "../../../../../../typings/customTypings";
import { BaseQuestionStore } from "./baseQuestionStore";
import { QuestionType, StudentTestQuestionListItemDto } from "../../../../../../typings/dataContracts";
import { FreeTextQuestionStore } from "../freeTextQuestion/freeTextQuestionStore";
import { StudentTestSessionApi } from "../../../../../../core/api/studentTestSessionApi";

export class StudentQuestionsContextStore {
    @observable public sessionId: string;
    @observable public isDataLoaded: boolean = false;
    @observable public questionsList: Array<StudentTestQuestionListItemDto> = [];
    @observable public questionsMap: Dictionary<QuestionMetadata> = {};

    constructor(sessionId: string) {
        this.sessionId = sessionId;
    }

    public loadData = async () => {
        this.isDataLoaded = false;
        const questions = await StudentTestSessionApi.getTestQuestions(this.sessionId);

        runInAction(() => {
            this.questionsList = questions;
            questions.forEach(q => this.questionsMap[q.id] = {
                type: q.type,
                id: q.id,
            });
            this.isDataLoaded = true;
        });
    };

    public getOrCreateStore = (id: string): BaseQuestionStore => {
        const info = this.questionsMap[id];
        if (!info.store) {
            info.store = this.createStore(info);
        }

        return info.store!;
    };

    private createStore = (info: QuestionMetadata) => {
        switch (info.type) {
            case QuestionType.FreeText:
                return new FreeTextQuestionStore(info.id, info.type);
            default:
                throw new Error(`Unsupported question type: ${info.type}`);
        }
    };
}

interface QuestionMetadata {
    store?: BaseQuestionStore;
    id: string;
    type: QuestionType;
}
