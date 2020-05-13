import { observable, runInAction } from "mobx";
import { AsyncInitializable, Dictionary } from "../../../../../../typings/customTypings";
import { BaseQuestionStore } from "./baseQuestionStore";
import { QuestionType } from "../../../../../../typings/dataContracts";
import { FreeTextQuestionStore } from "../freeTextQuestion/freeTextQuestionStore";
import { HttpApi } from "../../../../../../core/api/http/httpApi";
import { sortBy } from "lodash";
import { createContext, useContext } from "react";
import { ChoiceQuestionStore } from "../choiceQuestions/choiceQuestionStore";

export const StudentQuestionsContext = createContext<StudentQuestionsContextStore | undefined>(undefined);

export const useStudentQuestionsContext = (): StudentQuestionsContextStore => {
    return useContext(StudentQuestionsContext)!;
};

export class StudentQuestionsContextStore implements AsyncInitializable {
    @observable public initialized: boolean = false;

    @observable public sessionId: string;
    @observable public sessionState?: string;
    @observable public variant?: string;
    @observable public questionsList: Array<QuestionData> = [];
    @observable public questionsMap: Dictionary<QuestionMetadata> = {};

    constructor(sessionId: string) {
        this.sessionId = sessionId;
    }

    public init = async () => {
        this.initialized = false;
        const session = await loadData(this.sessionId);

        runInAction(() => {
            this.sessionState = session.state;
            this.variant = session.testVariant;
            this.questionsList = sortBy(session.questions, e => e.order);
            session.questions.forEach(
                q =>
                    (this.questionsMap[q.id] = {
                        type: q.type,
                        id: q.id,
                    }),
            );
            this.initialized = true;
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
            case QuestionType.QuestionWithChoice:
                return new ChoiceQuestionStore(info.id, this.sessionId, info.type);
            default:
                throw new Error(`Unsupported question type: ${info.type}`);
        }
    };
}

interface TestSession {
    state: string;
    testVariant: string;
    questions: Array<QuestionData>;
}

interface QuestionMetadata {
    store?: BaseQuestionStore;
    id: string;
    type: QuestionType;
}

interface QuestionData {
    id: string;
    isAnswered: boolean;
    order: number;
    type: QuestionType;
}

const query = `
query q($id: Uuid!) {
  session: studentTestSession(where: { id: $id }) {
    state
    testVariant
    questions {
      id
      isAnswered
      order
      type
    }
  }
}
`;

async function loadData(id: string): Promise<TestSession> {
    const { session } = await HttpApi.graphQl<{ session: TestSession }>(query, { id });
    return session;
}
