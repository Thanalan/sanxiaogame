using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace InterationExample
{
    /// <summary>
    /// 鼠标事件响应系统
    /// </summary>
    public class MouseSystem : IExecuteSystem, IInitializeSystem
    {
        private InputEntity _inputEntity;
        private InputContext _contexts;

        public MouseSystem(Contexts contexts)
        {
            _contexts = contexts.input;
        }

        public void Initialize()
        {
            _inputEntity = _contexts.interationExampleMouseEntity;
        }

        public void Execute()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _contexts.ReplaceInterationExampleMouse(MouseButton.LEFT, MouseButtonEvent.DOWN);
            }
            if (Input.GetMouseButtonDown(1))
            {
                _contexts.ReplaceInterationExampleMouse(MouseButton.RIGHT, MouseButtonEvent.DOWN);
            }
        }
    }
}