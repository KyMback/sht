import { CreatedEntityResponse, QuestionEditDetailsDto, QuestionType } from "../../typings/dataContracts";
import { HttpApi } from "../../core/api/http/httpApi";
import { TableResult } from "../../core/api/tableResult";

const createMutation = `
mutation($data: QuestionEditDetailsDtoInput!) {
  createQuestion(data: $data) {
    id
  }
}
`;

const updateMutation = `
mutation($data: QuestionEditDetailsDtoInput!, $id: Uuid!) {
  updateQuestion(data: $data, id: $id)
}
`;

interface QuestionsDetails {
    name: string;
    type: QuestionType;
    freeTextQuestion: {
        question: string;
    };
    choiceQuestion: {
        questionText: string;
        options: Array<{
            id: string;
            isCorrect: boolean;
            text: string;
        }>;
    };
}

const getQuestionDetailsQuery = `
query($id: Uuid!) {
  question(where: { id: $id }) {
    name
    type
    freeTextQuestion {
      question
    }
    choiceQuestion {
      questionText
      options {
        id
        isCorrect
        text
      }
    }
  }
}
`;

interface QuestionsExtendedDetails {
    name: string;
    type: QuestionType;
    createdBy: {
        id: string;
        email: string;
    };
    freeTextQuestion: {
        question: string;
    };
    choiceQuestion: {
        options: Array<{
            isCorrect: boolean;
            text: string;
        }>;
    };
}

const getQuestionExtendedDetailsQuery = `
query($id: Uuid!) {
  question(where: { id: $id }) {
    name
    type
    createdBy {
      id
      email
    }
    freeTextQuestion {
      question
    }
    choiceQuestion {
      options {
        isCorrect
        text
      }
      questionText
    }
  }
}
`;

export interface QuestionListItem {
    id: string;
    createdBy: {
        email: string;
    };
    name: string;
    type: QuestionType;
}

const getListItemsQuery = `
query($pageNumber: Int!, $pageSize: Int!) {
  questions(pageNumber: $pageNumber, pageSize: $pageSize) {
    items {
      id
      createdBy {
        email
      }
      name
      type
    }
    total
  }
}
`;

const importMutation = `
mutation($questionTemplatesFileId: Uuid!, $choiceQuestionsOptionsFileId: Uuid) {
  importQuestions(
    questionTemplatesFileId: $questionTemplatesFileId
    choiceQuestionsOptionsFileId: $choiceQuestionsOptionsFileId
  )
}`;

export class QuestionsActionsService {
    public static getExtendedDetails = async (id: string): Promise<QuestionsExtendedDetails> => {
        const { question } = await HttpApi.graphQl<{ question: QuestionsExtendedDetails }>(
            getQuestionExtendedDetailsQuery,
            { id },
        );
        return question;
    };

    public static getDetails = async (id: string): Promise<QuestionsDetails> => {
        const { question } = await HttpApi.graphQl<{ question: QuestionsDetails }>(getQuestionDetailsQuery, {
            id,
        });
        return question;
    };

    public static getListItems = async (
        pageNumber: number,
        pageSize: number,
    ): Promise<TableResult<QuestionListItem>> => {
        const { questions } = await HttpApi.graphQl<{ questions: TableResult<QuestionListItem> }>(getListItemsQuery, {
            pageNumber,
            pageSize,
        });
        return questions;
    };

    public static create = async (data: QuestionEditDetailsDto): Promise<CreatedEntityResponse> => {
        const { createQuestion } = await HttpApi.graphQl<{ createQuestion: CreatedEntityResponse }>(createMutation, {
            data,
        });

        return createQuestion;
    };

    public static update = async (id: string, data: QuestionEditDetailsDto) => {
        await HttpApi.graphQl(updateMutation, { data, id });
    };

    public static async import(questionTemplatesFileId: string, choiceQuestionsOptionsFileId?: string) {
        await HttpApi.graphQl(importMutation, { questionTemplatesFileId, choiceQuestionsOptionsFileId });
    }
}
