using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GameFeature : Feature
    {
        public GameFeature(Contexts contexts)
        {
            Add(new GameBoardSystem(contexts));
            Add(new ExchangeSysytem(contexts));
            Add(new MoveCompleteSystem(contexts));
            Add(new GetSameColorSystem(contexts));
            Add(new JudgeSameColorSystem(contexts));
            Add(new EliminationSystem(contexts));
            Add(new ExchangeBackSystem(contexts));
            Add(new FallSystem(contexts));
            Add(new DestroySystem(contexts));
            Add(new FillSystem(contexts));
            Add(new ChangeItemSpriteSystem(contexts));
            Add(new JudgeFormationSystem(contexts));
            Add(new EliminateSameColorSystem(contexts));
            Add(new EliminateHorizontalSysytem(contexts));
            Add(new ElimianteVerticalSystem(contexts));
            Add(new EliminateExplodeSystem(contexts));
            Add(new ScoreSystem(contexts));
            Add(new EliminateAudioSystem(contexts));
            Add(new ExchangeAudioSystem(contexts));
            Add(new FallAudioSystem(contexts));
        }
    }

}

