using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 视图层接口
    /// </summary>
    public interface IView
    {
        void Link(IEntity entity, IContext contex);
    }

}

