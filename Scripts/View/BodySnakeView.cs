using Assets.Scripts.ViewModel;
using UnityEngine;

namespace Assets.Scripts.View
{
    internal sealed class BodySnakeView : MonoBehaviour
    {
        private IBodyViewModel _bodyViewModel;

        public void Initialize(IBodyViewModel bodyViewModel)
        {
            _bodyViewModel = bodyViewModel;
            _bodyViewModel.OnEat += EatFood;
        }

        private void EatFood()
        {
            _bodyViewModel.AddBodyForSnake();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.collider.TryGetComponent<BodyFoodView>(out BodyFoodView bodyFoodView))
            {
                _bodyViewModel.StartAction();
            }
        }

        private void Update()
        {
            Debug.Log( _bodyViewModel._snake.transform.childCount);
            _bodyViewModel.MoveBody();
        }

        private void Start()
        {
            _bodyViewModel.CreateBodySnake();
        }
    }
}
