using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 点击响应系统
    /// </summary>
    public class ClickSystem : ReactiveSystem<InputEntity>
    {
        private Contexts _contexts;
        private ClickComponent _lastClickComponent;
        public ClickSystem(Contexts context) : base(context.input)
        {
            _contexts = context;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.GameClick);
        }

        protected override bool Filter(InputEntity entity)
        {
            return entity.hasGameClick;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            InputEntity input = entities.SingleEntity();
            var click = input.gameClick;
            var gameEntity = _contexts.game.GetEntitiesWithGameItemIndex(new CustomVector2(click.x, click.y));
            bool canMove = false;
            if (gameEntity != null)
            {
                canMove = gameEntity.SingleEntity().isGameMovable;
            }

            if (canMove)
            {
                if (_lastClickComponent == null)
                {
                    _lastClickComponent = new ClickComponent();
                }
                else
                {
                    //判断当前元素是否是上一个元素的上下左右四个元素之一
                    if ((click.x == _lastClickComponent.x - 1 && click.y == _lastClickComponent.y)
                        || (click.x == _lastClickComponent.x + 1 && click.y == _lastClickComponent.y)
                        || (click.y == _lastClickComponent.y - 1 && click.x == _lastClickComponent.x)
                        || (click.y == _lastClickComponent.y + 1 && click.x == _lastClickComponent.x))
                    {
                        ReplaceExchange(click);
                        ReplaceExchange(_lastClickComponent);
                        _lastClickComponent = null;
                    }
                }

                if (_lastClickComponent != null)
                {
                    _lastClickComponent.x = click.x;
                    _lastClickComponent.y = click.y;
                }
            }

        }

        private void ReplaceExchange(ClickComponent click)
        {
            var entitis = _contexts.game.GetEntitiesWithGameItemIndex(new CustomVector2(click.x, click.y));
            foreach (GameEntity entity in entitis)
            {
                entity.ReplaceGameExchange(ExchangeState.START);
            }
        }
    }
}
