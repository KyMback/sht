import { observable, runInAction } from "mobx";
import { Dictionary } from "../../../../../../typings/customTypings";
import { BaseQuestionStore } from "./baseQuestionStore";
import {
    QuestionType,
    StudentTestQuestionListItemDto,
    StudentTestSessionDto,
} from "../../../../../../typings/dataContracts";
import { FreeTextQuestionStore } from "../freeTextQuestion/freeTextQuestionStore";
import { HttpApi } from "../../../../../../core/api/http/httpApi";

export class StudentQuestionsContextStore {
    @observable public sessionId: string;
    @observable public sessionState?: string;
    @observable public variant?: string;
    @observable public isDataLoaded: boolean = false;
    @observable public questionsList: Array<StudentTestQuestionListItemDto> = [];
    @observable public questionsMap: Dictionary<QuestionMetadata> = {};

    constructor(sessionId: string) {
        this.sessionId = sessionId;
    }

    public loadData = async () => {
        this.isDataLoaded = false;
        const data = await loadData(this.sessionId);

        runInAction(() => {
            this.sessionState = data.session.state;
            this.variant = data.session.testVariant;
            this.questionsList = data.questions;
            data.questions.forEach(
                q =>
                    (this.questionsMap[q.id] = {
                        type: q.type,
                        id: q.id,
                    }),
            );
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
                return new FreeTextQuestionStore(info.id, this.sessionId, info.type);
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

interface LoadedData {
    session: StudentTestSessionDto;
    questions: Array<StudentTestQuestionListItemDto>;
}

const query = `
query q($id: Uuid!) {  
  session: studentTestSession(where: {id: $id}) {
    state
    testVariant
  }
  
  questions: studentTestQuestions(where: {studentTestSessionId:$id}, order_by:{number:ASC}) {
    id
    isAnswered
    number
    type
  }
}
`;

async function loadData(id: string): Promise<LoadedData> {
    return HttpApi.graphQl<LoadedData>(query, { id });
}
