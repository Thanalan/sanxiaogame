using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 点击组件
    /// </summary>
    [Input,Unique]
    public class ClickComponent : IComponent
    {
        public int x;
        public int y;
    }

    /// <summary>
    /// 滑动操作组件
    /// </summary>
    [Input, Unique]
    public class SlideComponent : IComponent
    {
        public CustomVector2 clickPos;
        public SlideDirection slideDirection;
    }
}
