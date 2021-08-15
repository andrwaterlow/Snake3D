using Assets.Scripts.ViewModel;
using UnityEngine;

namespace Assets.Scripts.View
{
    internal sealed class DeathForSnakeView : MonoBehaviour
    {
        IEndViewModel EndViewModel;

        public void Initialize(IEndViewModel endViewModel)
        {
            EndViewModel = endViewModel;
            EndViewModel.OnDeath += LoseGame;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent<MovementView>(out MovementView MovementView))
            {
                EndViewModel.ActionDeath();
            }
        }

        private void LoseGame()
        {
            Debug.Log("ЛОХ!!!");
            Time.timeScale = 0;
        }
    }
}
