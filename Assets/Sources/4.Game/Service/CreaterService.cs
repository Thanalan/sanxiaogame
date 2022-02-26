using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 创建新元素服务
    /// </summary>
    public class CreaterService
    {
        private static CreaterService _instance;
        public static CreaterService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CreaterService();
                }
                return _instance;
            }
        }

        private Contexts _contexts;

        public void Init(Contexts contexts)
        {
            _contexts = contexts;
        }

        /// <summary>
        /// 创建游戏面板
        /// </summary>
        public GameEntity CreateGameBoard()
        {
            var entity = _contexts.game.CreateEntity();
            entity.AddGameGameBoard(8, 9);
            return entity;
        }

        /// <summary>
        /// 生成可移动元素 随机
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public GameEntity CreateBallRandom(CustomVector2 index)
        {
            var entity = _contexts.game.CreateEntity();
            entity.isGameGameBoardItem = true;
            entity.isGameMovable = true;
            entity.AddGameItemIndex(index);
            entity.AddGameLoadPrefab(ResPath.PrefabPath + RandomPathService.RandomPath());
            entity.AddGameItemEffectState(ItemEffectName.NONE);
            return entity;
        }

        /// <summary>
        /// 生成障碍
        /// </summary> 
        public GameEntity CreateBloker(CustomVector2 index)
        {
            var entity = _contexts.game.CreateEntity();
            entity.isGameGameBoardItem = true;
            entity.isGameMovable = false;
            entity.AddGameItemIndex(index);
            entity.AddGameLoadPrefab(ResPath.BlockerPath);
            return entity;
        }

        /// <summary>
        /// 按照指定坐标生成元素
        /// </summary>
        /// <param name="nameIndex"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public GameEntity CreateBall(int nameIndex, int x, int y)
        {
            var entity = _contexts.game.CreateEntity();
            entity.isGameGameBoardItem = true;
            entity.isGameMovable = true;
            entity.AddGameFall(FallState.FALL);
            entity.AddGameItemIndex(new CustomVector2(x, y));
            entity.AddGameLoadPrefab(ResPath.PrefabPath + "Item" + nameIndex);
            entity.AddGameItemEffectState(ItemEffectName.NONE);
            return entity;
        }
    }

}

