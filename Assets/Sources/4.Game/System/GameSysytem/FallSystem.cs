using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using Game;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 下落响应系统
    /// </summary>
    public class FallSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _contexts;
        public FallSystem(Contexts context) : base(context.game)
        {
            _contexts = context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameGameBoardItem.Removed());
        }

        protected override bool Filter(GameEntity entity)
        {
            return !entity.isGameGameBoardItem;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            //每个元素检测自己能不能动
            //能动，就检测下一个位置是否为空
            //为空，下落
            //这里只负责在场景中已有元素的下落，新生成元素的下落不在这

            var gameBoard = _contexts.game.gameGameBoard;

            for (int column = 0; column < gameBoard.columns; column++)
            {
                for (int row = 1; row < gameBoard.rows; row++)
                {
                    var pos = new CustomVector2(column,row);
                    var movable = _contexts.game.GetEntitiesWithGameItemIndex(pos).Where(e => e.isGameMovable).ToArray();

                    foreach (GameEntity entity in movable)
                    {
                        MoveDown(entity);
                    }
                }
            }
        }

        private void MoveDown(GameEntity entity)
        {
            //检测是否有空位
            //有，下落到最下面的空位上

            var nextRow = GetEmptyItemService.Instance.GetNextEmptyRow(entity.gameItemIndex.index);

            if (nextRow < entity.gameItemIndex.index.y)
            {
                entity.ReplaceGameFall(FallState.FALL);
                entity.ReplaceGameItemIndex(new CustomVector2(entity.gameItemIndex.index.x,nextRow));
            }
        }
    }

}

