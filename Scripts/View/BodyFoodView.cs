using Assets.Scripts.ViewModel;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.View
{
    internal sealed class BodyFoodView : MonoBehaviour
    {
        private IBodyViewModel _bodyViewModel;

        public void Initialize(IBodyViewModel bodyViewModel)
        {
            _bodyViewModel = bodyViewModel;
            _bodyViewModel.OnEat += BecomeEated;
        }

        public void BecomeEated()
        {
            
        }
    }
}
