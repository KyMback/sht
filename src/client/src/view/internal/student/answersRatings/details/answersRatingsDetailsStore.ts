import { AsyncInitializable } from "../../../../../typings/customTypings";
import { action, computed, observable, runInAction } from "mobx";
import { HttpApi } from "../../../../../core/api/http/httpApi";
import { AnswersRatingsService } from "../../../../../services/answersRatings/answersRatingsService";
import { AnswersRatingEditDto } from "../../../../../typings/dataContracts";
import { sortBy } from "lodash";

export class AnswersRatingsDetailsStore implements AsyncInitializable {
    @observable public id: string;
    @observable public questionText?: string;
    @observable public ratingItems: Array<AnswerRatingItemData> = [];

    @computed public get orderedRatingItems(): Array<AnswerRatingItemData> {
        return sortBy(this.ratingItems, e => e.rating);
    }

    @computed
    public get canSave() {
        return true;
    }

    constructor(id: string) {
        this.id = id;
    }

    public init = async () => {
        await this.loadData();
    };

    public save = async () => {
        return AnswersRatingsService.rank(this.getDto());
    };

    @action
    public setRating = (item: AnswerRatingItemData, rating?: number) => {
        // TODO: add validation for rating
        item.rating = rating;
    };

    private loadData = async () => {
        const data = await loadData(this.id);

        runInAction(() => {
            this.questionText = data.questionText;
            this.ratingItems = data.ratingItems;
        });
    };

    private getDto = (): AnswersRatingEditDto => {
        return AnswersRatingEditDto.fromJS({
            id: this.id,
            ratingItems: this.ratingItems.map(e => ({
                id: e.id,
                rating: e.rating,
            })),
        });
    };
}

interface AnswerRatingData {
    questionText: string;
    ratingItems: Array<AnswerRatingItemData>;
}

interface AnswerRatingItemData {
    id: string;
    rating?: number;
    answer: {
        freeTextAnswer: {
            answer: string;
        };
    };
}

const query = `
query q($id: Uuid!) {
  answerRating(where: { id: $id }) {
    questionText
    ratingItems {
      id
      rating
      answer {
        freeTextAnswer {
          answer
        }
      }
    }
  }
}`;

async function loadData(id: string): Promise<AnswerRatingData> {
    const { answerRating } = await HttpApi.graphQl<{ answerRating: AnswerRatingData }>(query, {
        id,
    });
    return answerRating;
}
