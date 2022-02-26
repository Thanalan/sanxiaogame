using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 获取空接点服务
    /// </summary>
    public class GetEmptyItemService
    {

        public static GetEmptyItemService Instance { private set; get; } = new GetEmptyItemService();
        private Contexts _contexts;

        public void Init(Contexts contexts)
        {
            _contexts = contexts;
        }

        public int GetNextEmptyRow(CustomVector2 pos)
        {
            int row = pos.y;

            for (int i = pos.y - 1; i >= 0; i--)
            {
                var entity = _contexts.game.GetEntitiesWithGameItemIndex(new CustomVector2(pos.x, i)).ToArray();

                if(entity.Length == 0)
                {
                    //检测为空，标记位置
                    row = i;
                }
                else
                {
                    //检测到不可移动物体，跳过
                    if(!entity[0].isGameMovable)
                    {
                        continue;
                    }

                    //检测到可移动元素，停止循环
                    break;
                }
            }

            return row;
        }
    }
}

