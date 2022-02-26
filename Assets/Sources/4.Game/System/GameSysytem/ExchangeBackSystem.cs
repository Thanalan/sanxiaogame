using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 再次交换反应系统
    /// </summary>
    public class ExchangeBackSystem : ReactiveSystem<GameEntity>
    {
        public ExchangeBackSystem(Contexts context) : base(context.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameEliminate);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGameExchange
                   && entity.hasGameEliminate
                   && !entity.gameEliminate.canEliinate
                   && entity.gameExchange.exchangeState == ExchangeState.EXCHANGE;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                entity.ReplaceGameExchange(ExchangeState.EXCHANGE_BACK);
            }
        }
    }
}

