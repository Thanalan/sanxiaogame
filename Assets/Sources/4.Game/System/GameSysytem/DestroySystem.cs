using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Game
{
    public class DestroySystem : ICleanupSystem
    {
        private Contexts _contexts;
        private IGroup<GameEntity> _group;
        private List<GameEntity> _buffer = new List<GameEntity>(); 

        public DestroySystem(Contexts context)
        {
            _contexts = context;
            _group = _contexts.game.GetGroup(GameMatcher.GameDestroy);
        }

        public void Cleanup()
        {
            foreach (var entity in _group.GetEntities(_buffer))
            {
                entity.Destroy();
            }
        }
    }


}
