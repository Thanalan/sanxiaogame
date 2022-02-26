using System;
using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 消除音效
    /// </summary>
    public class EliminateAudioSystem : ReactiveSystem<GameEntity>
    {
        public EliminateAudioSystem(Contexts context) : base(context.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameEliminate);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGameItemEffectState && entity.gameEliminate.canEliinate;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity gameEntity in entities)
            {
                switch (gameEntity.gameItemEffectState.state)
                {
                    case ItemEffectName.NONE:
                        gameEntity.ReplaceGameAudio(AudioName.NormalBomb.ToString());
                        break;
                    case ItemEffectName.ELIMINATE_SAME_COLOR:
                        gameEntity.ReplaceGameAudio(AudioName.SpecialBomb.ToString());
                        break;
                    case ItemEffectName.ELIMINATE_HORIZONTAL:
                        gameEntity.ReplaceGameAudio(AudioName.SpecialBomb.ToString());
                        break;
                    case ItemEffectName.ELIMINATE_VERTICAL:
                        gameEntity.ReplaceGameAudio(AudioName.SpecialBomb.ToString());
                        break;
                    case ItemEffectName.EXPLODE:
                        gameEntity.ReplaceGameAudio(AudioName.SpecialBomb.ToString());
                        break;
                }
            }
        }
    }

    /// <summary>
    /// 交换声音
    /// </summary>
    public class ExchangeAudioSystem : ReactiveSystem<GameEntity>
    {
        public ExchangeAudioSystem(Contexts context) : base(context.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameExchange);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGameExchange
                   && (entity.gameExchange.exchangeState == ExchangeState.EXCHANGE
                       || entity.gameExchange.exchangeState == ExchangeState.EXCHANGE_BACK);
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                entity.ReplaceGameAudio(AudioName.Switch.ToString());
            }
        }
    }

    /// <summary>
    /// 下落音效系统
    /// </summary>
    public class FallAudioSystem : ReactiveSystem<GameEntity>
    {
        public FallAudioSystem(Contexts context) : base(context.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameItemIndex);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGameFall && entity.gameFall.state == FallState.FALL;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                entity.ReplaceGameAudio(AudioName.Fall.ToString());
            }
        }
    }
}
