using Entitas;
using System.Collections;
using System.Collections.Generic;
using Entitas.Unity;
using UnityEngine;

namespace InterationExample
{
    /// <summary>
    /// 添加视图层的系统
    /// </summary>
    public class AddViewSystem : ReactiveSystem<GameEntity>
    {
        private Transform _parent;
        private Contexts _context;
        public AddViewSystem(Contexts context) : base(context.game)
        {
            _parent = new GameObject("ViewParent").transform;
            _context = context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.InterationExampleSprite);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasInterationExampleSprite && !entity.hasInterationExampleView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                GameObject go = new GameObject("View");
                go.transform.SetParent(_parent);
                go.Link(entity, _context.game);
                entity.AddInterationExampleView(go.transform);
                entity.isInterationExampleMoveComplete = true;
            }
        }
    }
}
