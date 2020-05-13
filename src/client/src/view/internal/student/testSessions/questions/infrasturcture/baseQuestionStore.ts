import { observable } from "mobx";
import { AnswerStudentQuestionDto, QuestionType } from "../../../../../../typings/dataContracts";
import { AsyncInitializable } from "../../../../../../typings/customTypings";
import { StudentQuestionsService } from "../../../../../../services/studentQuestionsService";
import { notifications } from "../../../../../../components/notifications/notifications";
import { apiErrors, isExpected } from "../../../../../../core/api/http/apiError";
import { routingStore } from "../../../../../../stores/routingStore";

export abstract class BaseQuestionStore implements AsyncInitializable {
    @observable public id: string;
    @observable public sessionId: string;
    @observable public number?: string;
    @observable public type?: QuestionType;
    @observable public isInitialized: boolean;

    constructor(id: string, sessionId: string, type: QuestionType) {
        this.id = id;
        this.sessionId = sessionId;
        this.type = type;
        this.isInitialized = false;
    }

    public abstract init: () => Promise<any>;

    public submit = async () => {
        try {
            await StudentQuestionsService.answer(this.getDto());
            notifications.successfullySaved();
        } catch (e) {
            if (isExpected(e, apiErrors.studentTestSessionEnded)) {
                notifications.errorCode(apiErrors.studentTestSessionEnded);
                routingStore.goto(`/test-session/${this.sessionId}`);
                return;
            }

            throw e;
        }
    };

    protected abstract getDto: () => AnswerStudentQuestionDto;
}
