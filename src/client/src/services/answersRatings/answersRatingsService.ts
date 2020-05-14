import { AnswersRatingEditDto } from "../../typings/dataContracts";
import { HttpApi } from "../../core/api/http/httpApi";

const queries = {
    rank: `
mutation($data: AnswersRatingEditDtoInput!) {
  rankQuestionsAnswers(data: $data)
}`,
};

export class AnswersRatingsService {
    public static async rank(data: AnswersRatingEditDto) {
        return HttpApi.graphQl(queries.rank, { data });
    }
}
