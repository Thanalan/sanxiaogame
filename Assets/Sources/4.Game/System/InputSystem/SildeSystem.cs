using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Game
{
    /// <summary>
    /// 滑动响应类
    /// </summary>
    public class SildeSystem : ReactiveSystem<InputEntity>
    {
        private Contexts _context;

        public SildeSystem(Contexts contexts):base(contexts.input)
        {
            _context = contexts;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.GameSlide);
        }

        protected override bool Filter(InputEntity entity)
        {
            return entity.hasGameSlide;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            if(entities.Count == 1)
            {
                InputEntity entity = entities.SingleEntity();
                CustomVector2 pos = new CustomVector2(entity.gameSlide.clickPos.x, entity.gameSlide.clickPos.y);
                bool canMove = _context.game.GetEntitiesWithGameItemIndex(pos).SingleEntity().isGameMovable;

                if(canMove)
                {
                    var nextPos = NextPos(entity);
                    _context.input.ReplaceGameClick(nextPos.x, nextPos.y);
                }

                Debug.Log(entity.gameSlide.slideDirection);
            }
        }

        private CustomVector2 NextPos(InputEntity entity)
        {
            int x = entity.gameSlide.clickPos.x;
            int y = entity.gameSlide.clickPos.y;

            switch (entity.gameSlide.slideDirection)
            {
                case SlideDirection.LEFT:
                    x--;
                    break;
                case SlideDirection.RIGHT:
                    x++;
                    break;
                case SlideDirection.UP:
                    y++;
                    break;
                case SlideDirection.DOWN:
                    y--;
                    break;
            }

            x = LimitValue(x, 0, _context.game.gameGameBoard.columns -1 );
            y = LimitValue(y, 0, _context.game.gameGameBoard.rows - 1);

            return new CustomVector2(x, y);
        }

        //限制x和y的范围
        private int LimitValue(int value,int min,int max)
        {
            if(value < min)
            {
                value = min;
            }else if(value > max)
            {
                value = max;
            }

            return value;
        }
    }
}

