using System;
using UnityEngine;

namespace Controls
{
    public interface IControl
    {
        public event Action<Vector2> onShoot;
    }
}