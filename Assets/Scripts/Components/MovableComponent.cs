using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Ecs
{
    [Serializable]
    internal struct MovableComponent
    {
        public CharacterController CharacterController;
        public float Speed;
    }
}
