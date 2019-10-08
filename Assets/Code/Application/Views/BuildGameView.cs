using CityBuilder.Core.Game;
using DG.Tweening;
using UnityEngine;

namespace CityBuilder.Application.Views {
    public class BuildGameView : BaseGameView<BuildGameState> {

        [SerializeField]
        private RectTransform buildingsPanel;

        private void Awake() {
            buildingsPanel.pivot = new Vector2(1f, 0.5f);
        }

        public override void OnStateEnter() {
            gameObject.SetActive(true);
            buildingsPanel.DOPivotX(0f, 0.5f);
        }

        public override void OnStateExit() {
            buildingsPanel.DOPivotX(1f, 0.5f).OnComplete(() => gameObject.SetActive(false));
        }
    }
}
