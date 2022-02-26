using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace Game
{
    /// <summary>
    /// 游戏元素视图
    /// </summary>
    public class GameItemView : View, IGameItemIndexListener,IGameLoadSpriteListener
    {
        public override void Link(IEntity entity, IContext contex)
        {
            base.Link(entity, contex);
            _gameEntity.AddGameItemIndexListener(this);
            _gameEntity.AddGameLoadSpriteListener(this);
            transform.position = new Vector3(_gameEntity.gameItemIndex.index.x,Contexts.sharedInstance.game.gameGameBoard.rows);
            IView audioView = gameObject.AddComponent<AudioView>();
            audioView.Link(entity, contex);
        }
        
        public void OnGameItemIndex(GameEntity entity, CustomVector2 index)
        {
            transform.DOMove(new Vector3(index.x, index.y, 0), 0.3f).OnComplete(()=> _gameEntity.isGameMoveComplete = true);
        }

        public override void OnGameDestroy(GameEntity entity)
        {
            base.OnGameDestroy(entity);
            float time = 0.5f;
            transform.DOScale(Vector3.one*1.5f, time);
            transform.GetComponent<SpriteRenderer>().DOColor(Color.clear, time).OnComplete(()=>Destroy(gameObject));
        }

        public void OnGameLoadSprite(GameEntity entity, string name)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(ResPath.SpritePath + name);
        }
    }

}

