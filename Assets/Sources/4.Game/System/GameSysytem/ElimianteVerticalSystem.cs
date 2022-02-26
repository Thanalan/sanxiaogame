using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 消除一列元素的响应系统
    /// </summary>
    public class ElimianteVerticalSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _contexts;

        public ElimianteVerticalSystem(Contexts context) : base(context.game)
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
                   && entity.gameItemEffectState.state == ItemEffectName.ELIMINATE_VERTICAL;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var gameBoard = _contexts.game.gameGameBoard;
            GameEntity[] temp;

            foreach (GameEntity entity in entities)
            {
                for (int row = 0; row < gameBoard.rows; row++)
                {
                    temp =
                       _contexts.game.GetEntitiesWithGameItemIndex(
                           new CustomVector2(entity.gameItemIndex.index.x, row)).ToArray();

                    if (temp.Length == 1)
                    {
                        temp[0].isGameDestroy = true;
                    }
                }
            }
        }
    }

}

