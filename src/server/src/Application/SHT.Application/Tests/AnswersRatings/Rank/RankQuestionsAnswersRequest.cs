using SHT.Application.Common;
using SHT.Application.Tests.AnswersRatings.Contracts;

namespace SHT.Application.Tests.AnswersRatings.Rank
{
    public class RankQuestionsAnswersRequest : BaseRequest<AnswersRatingEditDto>
    {
        public RankQuestionsAnswersRequest(AnswersRatingEditDto data)
            : base(data)
        {
        }
    }
}