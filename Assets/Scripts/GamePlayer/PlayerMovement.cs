using System;
using System.Net.NetworkInformation;
using Controls;
using UnityEngine;
using Zenject;

namespace GamePlayer
{
    public class PlayerMovement: MonoBehaviour
    {
        private Rigidbody2D _rb;
        private IControl _control;
        private PlayerData _data;
        private Camera _camera;

        [Inject]
        public void Construct(Rigidbody2D rb, IControl control, PlayerData data, Camera camera)
        {
            _rb = rb;
            _control = control;
            _data = data;
            _camera = camera;
        }

        private void FixedUpdate()
        {
            _rb.velocity = _control.moveDirection * _data.speed;
        }

        private void Update()
        {
            _camera.transform.position = transform.position + Vector3.back * 10;
        }
    }
}