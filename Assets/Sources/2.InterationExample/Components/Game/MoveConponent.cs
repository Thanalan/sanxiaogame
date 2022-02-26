using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace InterationExample
{
    /// <summary>
    /// 移动组件
    /// </summary>
    public class MoveConponent : IComponent
    {
        //目标位置
        public Vector3 targetPos;
    }
}
