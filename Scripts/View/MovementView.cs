using Assets.Scripts.ViewModel;
using UnityEngine;

namespace Assets.Scripts.View
{
    internal sealed class MovementView : MonoBehaviour
    {
        private IMovementViewModel _movementViewModel;

        public void Initialize(IMovementViewModel movementViewModel)
        {
            _movementViewModel = movementViewModel;
            _movementViewModel.GetKeyUp += GoUp;
            _movementViewModel.GetKeyDown += GoDown;
            _movementViewModel.GetKeyLeft += GoLeft;
            _movementViewModel.GetKeyRight += GoRight;
        }

        private void GoUp()
        {
            _movementViewModel.MovementModel.CourseCurrent =
                _movementViewModel.MovementModel.CourseUp;
        }

        private void GoDown()
        {
            _movementViewModel.MovementModel.CourseCurrent =
                _movementViewModel.MovementModel.CourseDown;
        }

        private void GoLeft()
        {
            _movementViewModel.MovementModel.CourseCurrent =
                _movementViewModel.MovementModel.CourseLeft;
        }

        private void GoRight()
        {
            _movementViewModel.MovementModel.CourseCurrent =
                _movementViewModel.MovementModel.CourseRight;
        }

        private void Update()
        {
            _movementViewModel.Move();
        }
    }
}
