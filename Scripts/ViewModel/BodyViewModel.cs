using Assets.Scripts.Model;
using System;
using UnityEngine;

namespace Assets.Scripts.ViewModel
{
    internal sealed class BodyViewModel : IBodyViewModel
    {
        public IBodyModel BodyModel { get; }

        public event Action OnEat;
        public GameObject _snake { get; set; }

        public BodyViewModel(IBodyModel bodyModel, GameObject snake)
        {
            BodyModel = bodyModel;
            _snake = snake;
        }

        public void StartAction()
        {
            OnEat.Invoke();
        }

        public void MoveBody()
        {     
    
        }

        public void CreateBodySnake()
        {
            CreateBodyForStart();
            CreateBodyForStart();

            BodyModel.SnakeBody[BodyModel.SnakeBody.Count - 1].transform.SetParent(
                BodyModel.SnakeBody[BodyModel.SnakeBody.Count - 2].transform);

            BodyModel.SnakeBody[BodyModel.SnakeBody.Count - 2].transform.SetParent(
                _snake.transform.GetChild(0));
        }

        private void CreateBodyForStart()
        {
            CreateNewBody();
            BodyModel.SnakeBody.Add(BodyModel.Newbody);
        }

        public void AddBodyForSnake()
        {
            CreateNewBody();
            BodyModel.SnakeBody.Add(BodyModel.Newbody);
            BodyModel.SnakeBody[BodyModel.SnakeBody.Count - 1].transform.SetParent(
                BodyModel.SnakeBody[BodyModel.SnakeBody.Count - 2].transform);
        }

        private void CreateNewBody()
        {
            SetNewPositionForBody();
            BodyModel.Newbody = GameObject.Instantiate(BodyModel.Body, BodyModel.PositionOfNewBody, Quaternion.identity);
        }

        private void SetNewPositionForBody()
        {
            GetLastBodyPosition();
            float sizeOfBody = 0.5f;
            Vector3 positionOfNewBody;
            float newPositionX = BodyModel.PositionOfLastBody.x;
            float newPositionY = BodyModel.PositionOfLastBody.y;
            float newPositionZ = BodyModel.PositionOfLastBody.z + sizeOfBody;
            positionOfNewBody = BodyModel.PositionOfLastBody;
            positionOfNewBody.Set(newPositionX, newPositionY, newPositionZ);
            BodyModel.PositionOfNewBody = positionOfNewBody;
        }

        private void GetLastBodyPosition()
        {
            var numberOfChild = BodyModel.SnakeBody.Count - 1;

            if (BodyModel.SnakeBody.Count < 1)
            {
                BodyModel.PositionOfLastBody = _snake.transform.GetChild(0).position;
            }
            else
            {
                BodyModel.PositionOfLastBody = BodyModel.SnakeBody[numberOfChild].transform.position;
            } 
        }
    }
}
