using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 元素填充系统
    /// </summary>
    public class FillSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _contexts;

        public FillSystem(Contexts context) : base(context.game)
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
            var gameBoard = _contexts.game.gameGameBoard;

            for (int column = 0; column < gameBoard.columns; column++)
            {
                //获取最上层之上的坐标，为了遍历到最上面一行
                var pos = new CustomVector2(column, gameBoard.rows + 1);
                //得到row最小的位置
                var rowPosMin = GetEmptyItemService.Instance.GetNextEmptyRow(pos);

                for (int row = rowPosMin; row < gameBoard.rows; row++)
                {
                    CreaterService.Instance.CreateBallRandom(new CustomVector2(column, row));
                }
            }
        }
    }


}

