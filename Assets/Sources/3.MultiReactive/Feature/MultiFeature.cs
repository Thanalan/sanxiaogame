using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MultiReactive
{
    public class MultiFeature : Feature
    {
        public MultiFeature(Contexts contexts)
        {
            Add(new MultDestroySystem(contexts));
            Add(new MultiViewSystem(contexts));
        }
    }
}
