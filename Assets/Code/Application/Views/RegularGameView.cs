using CityBuilder.Core.Game;

namespace CityBuilder.Application.Views {
    public class RegularGameView : BaseGameView<RegularGameState> {

        public override void OnStateEnter() {
            gameObject.SetActive(true);
        }

        public override void OnStateExit() {
            gameObject.SetActive(false);
        }
    }
}
