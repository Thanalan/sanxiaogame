using Entitas;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 爆炸特殊元素的响应部分
    /// </summary>
    public class EliminateExplodeSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _contexts;

        public EliminateExplodeSystem(Contexts context) : base(context.game)
        {
            _contexts = context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameDestroy);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGameItemEffectState
                   && entity.gameItemEffectState.state == ItemEffectName.EXPLODE;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                CustomVector2 pos = entity.gameItemIndex.index;
                GameEntity[] temp;

                for (int x = pos.x -1 ; x <= pos.x + 1; x++)
                {
                    for (int y = pos.y -1; y <= pos.y +1; y++)
                    {
                     
                        if(x< 0 || y <0)
                            continue;

                        temp = _contexts.game.GetEntitiesWithGameItemIndex(new CustomVector2(x, y)).ToArray();

                        if (temp.Length == 1)
                        {
                            temp[0].isGameDestroy = true;
                        }
                    }
                }
            }
        }
    }
}

