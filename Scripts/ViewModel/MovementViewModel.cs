using Assets.Scripts.Model;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.ViewModel
{
    internal sealed class MovementViewModel : IMovementViewModel
    {
        public event Action GetKeyUp;
        public event Action GetKeyDown;
        public event Action GetKeyLeft;
        public event Action GetKeyRight;

        private GameObject _snake;

        public IMovementModel MovementModel { get; }

        public MovementViewModel(IMovementModel movementModel, GameObject gameObject)
        {
            MovementModel = movementModel;
            _snake = gameObject;
        }

        public void Move()
        {
            OnAction();
            var Speed = MovementModel.Speed * Time.deltaTime;
            _snake.transform.GetChild(0).transform.Translate(MovementModel.CourseCurrent * Speed);
        }
        
        private void OnAction()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
                GetKeyUp.Invoke();

            if (Input.GetKeyDown(KeyCode.DownArrow))
                GetKeyDown.Invoke(); 

            if (Input.GetKeyDown(KeyCode.LeftArrow))
                GetKeyLeft.Invoke();

            if (Input.GetKeyDown(KeyCode.RightArrow))
                GetKeyRight.Invoke();
        }
    }
}
