using System;
using System.Net.NetworkInformation;
using Controls;
using Entities;
using UnityEngine;
using Zenject;

namespace GamePlayer
{
    public class EntityMovement: MonoBehaviour
    {
        private Rigidbody2D _rb;
        private IControl _control;
        private IMovementData _data;

        [Inject]
        public void Construct(Rigidbody2D rb, IControl control, IMovementData data)
        {
            _rb = rb;
            _control = control;
            _data = data;
        }

        private void FixedUpdate()
        {
            _rb.velocity = _control.moveDirection * _data.speed;
        }
    }
}