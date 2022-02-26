using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 消除一行特殊元素的响应系统
    /// </summary>
    public class EliminateHorizontalSysytem : ReactiveSystem<GameEntity>
    {
        private Contexts _contexts;

        public EliminateHorizontalSysytem(Contexts context) : base(context.game)
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
                   && entity.gameItemEffectState.state == ItemEffectName.ELIMINATE_HORIZONTAL;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var gameBoard = _contexts.game.gameGameBoard;
            GameEntity[] temp;

            foreach (GameEntity entity in entities)
            {
                for (int column = 0; column < gameBoard.columns; column++)
                {
                    temp =
                        _contexts.game.GetEntitiesWithGameItemIndex(new CustomVector2(column,
                            entity.gameItemIndex.index.y)).ToArray();

                    if (temp.Length == 1)
                    {
                        temp[0].isGameDestroy = true;
                    }
                }
            }
        }
    }

}

