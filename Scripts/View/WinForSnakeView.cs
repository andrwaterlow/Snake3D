using Assets.Scripts.ViewModel;
using UnityEngine;

namespace Assets.Scripts.View
{
    internal sealed class WinForSnakeView : MonoBehaviour
    {
        IEndViewModel EndViewModel;

        public void Initialize(IEndViewModel endViewModel)
        {
            EndViewModel = endViewModel;
            EndViewModel.OnWin += WinGame;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent<BodyFoodView> (out BodyFoodView foodView))
            {
                EndViewModel.EatFood();
            }
        }

        private void WinGame()
        {
            Debug.Log("ПОБЕДА!!!");
        }
    }
}
