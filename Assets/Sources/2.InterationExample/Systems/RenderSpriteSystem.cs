using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterationExample
{
    /// <summary>
    /// 添加图片
    /// </summary>
    public class RenderSpriteSystem : ReactiveSystem<GameEntity>
    {
        public RenderSpriteSystem(Contexts context) : base(context.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.InterationExampleSprite);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasInterationExampleSprite && entity.hasInterationExampleView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                Transform trans = entity.interationExampleView.viewTrans;
                SpriteRenderer sr = trans.GetComponent<SpriteRenderer>();
                if (sr == null) sr = trans.gameObject.AddComponent<SpriteRenderer>();
                sr.sprite = Resources.Load<Sprite>(entity.interationExampleSprite.spriteName);
            }
        }
    }
}
