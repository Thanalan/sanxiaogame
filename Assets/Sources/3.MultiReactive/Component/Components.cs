using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace MultiReactive
{
    /// <summary>
    /// 多上下文公用的销毁组件
    /// </summary>
    [Game, Input, Ui]
    public class DeatroyedComponent : IComponent
    {

    }

    /// <summary>
    /// 多上下文公用的销毁组件
    /// </summary>
    [Game, Input, Ui]
    public class ViewComponent : IComponent
    {
        public Transform viewTrans;
    }

    [Game, Event(EventTarget.Any)]
    public class NameComponent : IComponent
    {
        [EntityIndex]
        public string name;
    }
}

