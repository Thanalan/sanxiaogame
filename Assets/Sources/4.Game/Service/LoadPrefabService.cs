using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 加载预制体服务
    /// </summary>
    public class LoadPrefabService : IGameLoadPrefabListener
    {
        public static LoadPrefabService Instance { private set; get; } = new LoadPrefabService();
        private Contexts _contexts;
        private Transform _settleParent;
        private Transform _movableParent;
        
        public virtual void Init(Contexts contexts,Transform gameController)
        {
            _contexts = contexts;
            contexts.game.CreateEntity().AddGameLoadPrefabListener(this);
            CreateSubParent(gameController);
        }

        private void CreateSubParent(Transform parent)
        {
            _settleParent = new GameObject("settle").transform;
            _settleParent.SetParent(parent);
            _movableParent = new GameObject("movable").transform;
            _movableParent.SetParent(parent);
        }

        public virtual void OnGameLoadPrefab(GameEntity entity, string path)
        {
            Transform temp = null;
            if (entity.isGameMovable)
            {
                temp = _movableParent;
            }
            else
            {
                temp = _settleParent;
            }

            GameObject go = Resources.Load<GameObject>(path);
            var view = Object.Instantiate(go, temp).GetComponent<IView>();
            view.Link(entity, _contexts.game);
        }
    }
}

