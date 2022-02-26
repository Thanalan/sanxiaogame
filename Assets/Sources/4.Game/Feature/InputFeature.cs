using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class InputFeature : Feature
    {
        public InputFeature(Contexts contexts)
        {
            Add(new ClickSystem(contexts));
            Add(new SildeSystem(contexts));
        }
    }

}

