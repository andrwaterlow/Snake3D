using UnityEngine;
using Assets.Scripts.View;
using Assets.Scripts.ViewModel;
using Assets.Scripts.Model;

namespace Assets.Scripts
{
    internal sealed class Starter : MonoBehaviour
    {
        [SerializeField] private GameObject _snake;
        [SerializeField] private GameObject _playArea;
        [SerializeField] private MovementView _movementView;
        [SerializeField] private BodySnakeView _bodySnakeView;
        [SerializeField] private BodyFoodView _bodyFoodView;
        [SerializeField] private DeathForSnakeView _deathForSnakeView;
        [SerializeField] private WinForSnakeView _winForSnakeView;
        [SerializeField] private EatedFoodView _eatedFoodView;
        [SerializeField] private FoodView _foodView;

        private void Start()
        {
            MovementModel movementModel = new MovementModel(5.0f);
            MovementViewModel movementViewModel = new MovementViewModel(movementModel, _snake);
            _movementView.Initialize(movementViewModel);

            BodyModel bodyModel = new BodyModel();
            BodyViewModel bodyViewModel = new BodyViewModel(bodyModel, _snake);
            _bodyFoodView.Initialize(bodyViewModel);
            _bodySnakeView.Initialize(bodyViewModel);

            EndModel endModel = new EndModel(1);
            EndViewModel endViewModel = new EndViewModel(endModel);
            _deathForSnakeView.Initialize(endViewModel);
            _winForSnakeView.Initialize(endViewModel);

            FoodModel foodModel = new FoodModel(_playArea);
            FoodViewModel foodViewModel = new FoodViewModel(foodModel);
            _eatedFoodView.Initialize(foodViewModel);
            _foodView.Initialize(foodViewModel);
        }
    }
}
