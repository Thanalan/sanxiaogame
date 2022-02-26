using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 特殊元素修改图片的响应系统
    /// </summary>
    public class ChangeItemSpriteSystem : ReactiveSystem<GameEntity>
    {
        public ChangeItemSpriteSystem(Contexts context) : base(context.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameItemEffectState);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGameItemEffectState && entity.gameItemEffectState.state != ItemEffectName.NONE;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                string[] buffer = entity.gameLoadPrefab.path.Split('/');
                string itemName = "";
                if (buffer.Length == 2)
                {
                    itemName = buffer[1];
                }
                else
                {
                    continue;
                }

                switch (entity.gameItemEffectState.state)
                {
                    case ItemEffectName.ELIMINATE_SAME_COLOR:
                        itemName += ResPath.AllPostfix;//Item0_1
                        break;
                    case ItemEffectName.ELIMINATE_HORIZONTAL:
                        itemName += ResPath.HorizontalPostfix;
                        break;
                    case ItemEffectName.ELIMINATE_VERTICAL:
                        itemName += ResPath.VertialPostfix;
                        break;
                    case ItemEffectName.EXPLODE:
                        itemName += ResPath.ExplodePostfix;
                        break;
                }

                //加载图片组件
                entity.ReplaceGameLoadSprite(itemName);
            }
        }
    }
}

