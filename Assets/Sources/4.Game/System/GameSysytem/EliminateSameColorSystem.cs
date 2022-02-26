using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// ELIMINATE_SAME_COLOR特殊元素的消除响应系统
    /// </summary>
    public class EliminateSameColorSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _contexts;

        public EliminateSameColorSystem(Contexts context) : base(context.game)
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
                   && entity.gameItemEffectState.state == ItemEffectName.ELIMINATE_SAME_COLOR;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                var gameBoard = _contexts.game.gameGameBoard;
                string colorName = entity.gameLoadPrefab.path;
                GameEntity temp;

                for (int column = 0; column < gameBoard.columns; column++)
                {
                    for (int row = 0; row < gameBoard.rows; row++)
                    {
                        temp = _contexts.game.GetEntitiesWithGameItemIndex(new CustomVector2(column, row))
                            .FirstOrDefault(u => u.gameLoadPrefab.path == colorName);

                        if (temp != null) temp.isGameDestroy = true;
                    }
                }
            }
           
        }
    }

}

