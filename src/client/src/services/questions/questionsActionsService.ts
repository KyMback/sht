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

const getQuestionDetailsQuery = `
query($id: Uuid!) {
  question(where: { id: $id }) {
    name
    type
    freeTextQuestion {
      question
    }
  }
}
`;

const getQuestionExtendedDetailsQuery = `
query($id: Uuid!) {
  question(where: { id: $id }) {
    name
    type
    createdById
    freeTextQuestion {
      question
    }
  }
}
`;

const getListItemsQuery = `
query($pageNumber: Int!, $pageSize: Int!) {
  questions(pageNumber: $pageNumber, pageSize: $pageSize) {
    items {
      id
      createdById
      name
      type
    }
    total
  }
}
`;

interface QuestionsDetails {
    name: string;
    type: QuestionType;
    freeTextQuestion: {
        question: string;
    };
}

interface QuestionsExtendedDetails {
    name: string;
    type: QuestionType;
    createdById: string;
    freeTextQuestion: {
        question: string;
    };
}

export interface QuestionListItem {
    id: string;
    createdById: string;
    name: string;
    type: QuestionType;
}

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
}
