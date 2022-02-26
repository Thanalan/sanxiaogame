using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 交换运动部分响应系统
    /// </summary>
    public class ExchangeSysytem : ReactiveSystem<GameEntity>
    {
        public ExchangeSysytem(Contexts context) : base(context.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameExchange);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGameExchange
                   && (entity.gameExchange.exchangeState == ExchangeState.START
                       || entity.gameExchange.exchangeState == ExchangeState.EXCHANGE_BACK);
        }

        protected override void Execute(List<GameEntity> entities)
        {
            if (entities.Count == 2)
            {
                Exchange(entities[0], entities[1]);
            }
        }

        //交换逻辑部分
        private void Exchange(GameEntity one, GameEntity two)
        {
            var onePos = one.gameItemIndex.index;
            var twoPos = two.gameItemIndex.index;

            one.ReplaceGameItemIndex(twoPos);
            two.ReplaceGameItemIndex(onePos);

            SetExchangeState(one);
            SetExchangeState(two);
        }
        //设置交换状态标记
        private void SetExchangeState(GameEntity entity)
        {
            if (entity.gameExchange.exchangeState == ExchangeState.START)
            {
                entity.ReplaceGameExchange(ExchangeState.EXCHANGE);
            }
            else if(entity.gameExchange.exchangeState == ExchangeState.EXCHANGE_BACK)
            {
                entity.ReplaceGameExchange(ExchangeState.END);
            }
        }
    }

}

