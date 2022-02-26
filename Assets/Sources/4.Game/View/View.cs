using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 视图层基类
    /// </summary>
    public class View : MonoBehaviour, IView,IGameDestroyListener
    {
        protected GameEntity _gameEntity;
        public virtual void Link(IEntity entity, IContext context)
        {
            if (entity is GameEntity)
            {
                _gameEntity = entity as GameEntity;
            }
            else
            {
                Debug.LogError("实体类型错误");
                return;
            }

            _gameEntity.AddGameDestroyListener(this);
            gameObject.Link(entity, context);
        }

        public virtual void OnGameDestroy(GameEntity entity)
        {
            gameObject.Unlink();
        }
    }

}

