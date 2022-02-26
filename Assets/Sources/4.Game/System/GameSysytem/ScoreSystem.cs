using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 计分系统
    /// </summary>
    public class ScoreSystem : ReactiveSystem<GameEntity>,IInitializeSystem
    {
        private Contexts _contexts;

        public ScoreSystem(Contexts context) : base(context.game)
        {
            _contexts = context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameGameBoardItem.Removed());
        }

        protected override bool Filter(GameEntity entity)
        {
            return !entity.isGameGameBoardItem;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            int score = _contexts.game.gameScore.score;
            _contexts.game.ReplaceGameScore(score + entities.Count);
        }

        public void Initialize()
        {
            _contexts.game.ReplaceGameScore(0);
        }
    }
}

