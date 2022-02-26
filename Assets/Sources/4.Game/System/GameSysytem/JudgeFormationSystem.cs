using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 在判断是否满足消除条件后，判断是否满足队形
    /// </summary>
    public class JudgeFormationSystem : ReactiveSystem<GameEntity>
    {
        public JudgeFormationSystem(Contexts context) : base(context.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameJudgeFormation);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isGameJudgeFormation;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                if (entity.gameItemEffectState.state == ItemEffectName.NONE)
                {
                    JudgeItem(entity);
                }
                else
                {
                    entity.isGameJudgeFormation = false;
                }

                entity.ReplaceGameEliminate(true);
            }
        }
        //判断是否满足特效元素生成要求
        private void JudgeItem(GameEntity entity)
        {
            if (JudgeEliminateAll(entity.gameDetectionSameItem))
            {
                entity.ReplaceGameItemEffectState(ItemEffectName.ELIMINATE_SAME_COLOR);
            }
            else if (JudgeEliminateHorizontal(entity.gameDetectionSameItem))
            {
                entity.ReplaceGameItemEffectState(ItemEffectName.ELIMINATE_HORIZONTAL);
            }
            else if (JudgeEliminateVertical(entity.gameDetectionSameItem))
            {
                entity.ReplaceGameItemEffectState(ItemEffectName.ELIMINATE_VERTICAL);
            }
            else if (JudgeExplode(entity.gameDetectionSameItem))
            {
                entity.ReplaceGameItemEffectState(ItemEffectName.EXPLODE);
            }
            else
            {
                entity.isGameJudgeFormation = false;
            }
        }

        //消除所有相同颜色的元素（条件：五个及五个以上元素连成一条直线）
        private bool JudgeEliminateAll(DetectionSameItem listComponent)
        {
            //判断行 是否满足条件
            if (listComponent._leftEntities.Count + listComponent._rightEntities.Count >= 4)
                return true;
            //判断列 是否满足条件
            if (listComponent._upEntities.Count + listComponent._downEntities.Count >= 4)
                return true;

            return false;
        }

        // 消除行（条件：四个元素连成横线）
        private bool JudgeEliminateHorizontal(DetectionSameItem listComponent)
        {
            //判断行 是否满足条件
            if (listComponent._leftEntities.Count + listComponent._rightEntities.Count == 3)
                return true;

            return false;
        }

        // 消除列（条件：四个元素连成竖线）
        private bool JudgeEliminateVertical(DetectionSameItem listComponent)
        {
            //判断列 是否满足条件
            if (listComponent._upEntities.Count + listComponent._downEntities.Count == 3)
                return true;

            return false;
        }

        //爆炸消除以此元素为中心的九宫格范围（条件：横竖都满足三个及三个元素以上）
        private bool JudgeExplode(DetectionSameItem listComponent)
        {
            int countHor = listComponent._leftEntities.Count + listComponent._rightEntities.Count;
            int countVer = listComponent._upEntities.Count + listComponent._downEntities.Count;

            if (countHor >= 2 && countVer >= 2)
                return true;

            return false;
        }
    }
}

