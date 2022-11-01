using System;
using UnityEngine;
using Zenject;

namespace Controls
{
    public class PCControl: IControl ,ITickable
    {
        public event Action<Vector2> onShoot;

        
        public void Tick()
        {
            if(Input.GetKeyDown(KeyCode.Space))
                onShoot?.Invoke(Vector2.right);
        }

    }
}