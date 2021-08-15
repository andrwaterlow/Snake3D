using Assets.Scripts.ViewModel;
using System;
using UnityEngine;

namespace Assets.Scripts.View
{
    class EatedFoodView : MonoBehaviour
    {
        private IFoodViewModel _foodViewModel;

        public void Initialize(IFoodViewModel foodViewModel)
        {
            _foodViewModel = foodViewModel;
            _foodViewModel.OnBeEated += EatFood;
        }

        private void EatFood()
        {
            _foodViewModel.CreateNewFood();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out FoodView foodView))
            {
                _foodViewModel.ActionEated();
            }
        }
    }
}
