using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 游戏面板的响应系统
    /// </summary>
    public class GameBoardSystem : ReactiveSystem<GameEntity>,IInitializeSystem
    {
        private IGroup<GameEntity> _itemsGroup;
        public GameBoardSystem(Contexts context) : base(context.game)
        {
            _itemsGroup = context.game.GetGroup(GameMatcher.GameGameBoardItem);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameGameBoard);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGameGameBoard;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var gameBoard = entities.SingleEntity().gameGameBoard;
            foreach (GameEntity entity in _itemsGroup)
            {
                //todo:超出游戏面板范围的元素需要消除
            }
        }

        //初始化游戏面板，生成内部元素
        public void Initialize()
        {
            var gameBoard = CreaterService.Instance.CreateGameBoard().gameGameBoard;
            var list = GetDataList();

            for (int row = 0; row < gameBoard.rows; row++)
            {
                for (int index = 0; index < list[row].Count; index++)
                {
                    CreaterService.Instance.CreateBall(list[row][index], index, row);
                }
            }
        }

        private List<List<int>> GetDataList()
        {
            var model = Models.Instance.DataModel.Level[0];
            List<List<int>> list = new List<List<int>>();
            list.Add(model.row_0);
            list.Add(model.row_1);
            list.Add(model.row_2);
            list.Add(model.row_3);
            list.Add(model.row_4);
            list.Add(model.row_5);
            list.Add(model.row_6);
            list.Add(model.row_7);
            list.Add(model.row_8);
            return list;
        }
        //根据随机生成障碍的概率判断是否可以生成障碍
        private bool RandomBlocker()
        {
            int num = Random.Range(0, 10);

            if (num < 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

