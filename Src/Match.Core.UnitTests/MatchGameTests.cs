namespace Match.Core.UnitTests
{
    public class MatchGameTests
    {
        private MatchGame _matchGame;

        [SetUp]
        public void SetUp()
        {
            _matchGame = new();
        }

        [Test]
        public void ShouldDealWithSuitsOfTwoCardsMustMatchCondition()
        {
            _matchGame.Play(3, 1);
        }

        [Test]
        public void ShouldDealWithValuesOfTwoCardsMustMatchCondition()
        {
            _matchGame.Play(3, 2);
        }

        [Test]
        public void ShouldDealWithBothSuitAndValueMustMatchCondition()
        {
            _matchGame.Play(3, 3);
        }
    }
}
