using Tool;
using UnityEngine;

namespace Game.TapeBackground
{
    internal class TapeBackgroundController : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath("Prefabs/Background");

        private readonly SubscriptionProperty<float> _diff;
        private readonly ISubscriptionProperty<float> _leftMove;
        private readonly ISubscriptionProperty<float> _rightMove;
        private readonly ISubscriptionProperty<float> _jumpMove;

        private TapeBackgroundView _view;


        public TapeBackgroundController(
            SubscriptionProperty<float> leftMove,
            SubscriptionProperty<float> rightMove,
            SubscriptionProperty<float> jumpMove)
        {
            _view = LoadView();
            _diff = new SubscriptionProperty<float>();

            _leftMove = leftMove;
            _rightMove = rightMove;
            _jumpMove = jumpMove;

            _view.Init(_diff);

            _leftMove.SubscribeOnChange(MoveLeft);
            _rightMove.SubscribeOnChange(MoveRight);
            _jumpMove.SubscribeOnChange(MoveJump);
        }

        protected override void OnDispose()
        {
            _leftMove.UnSubscribeOnChange(MoveLeft);
            _rightMove.UnSubscribeOnChange(MoveRight);
            _jumpMove.UnSubscribeOnChange(MoveJump);
        }


        private TapeBackgroundView LoadView()
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_viewPath);
            GameObject objectView = Object.Instantiate(prefab);
            AddGameObject(objectView);

            return objectView.GetComponent<TapeBackgroundView>();
        }

        private void MoveLeft(float value) =>
            _diff.Value = -value;

        private void MoveRight(float value) =>
            _diff.Value = value;

        private void MoveJump(float value) =>
            _diff.Value = 0;
    }
    
}
