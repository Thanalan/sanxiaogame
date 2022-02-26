using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Game
{
    /// <summary>
    /// 游戏面板
    /// </summary>
    [Game,Unique]
    public class GameBoardComponent : IComponent
    {
        /// <summary>
        /// 列
        /// </summary>
        public int columns;
        /// <summary>
        /// 行
        /// </summary>
        public int rows;
    }

    /// <summary>
    /// 游戏界面元素
    /// </summary>
    [Game]
    public class GameBoardItemComponent : IComponent
    {
        
    }

    /// <summary>
    /// 游戏元素消除组件
    /// </summary>
    [Game, Event(EventTarget.Self)]
    public class DestroyComponent : IComponent
    {
        
    }

    /// <summary>
    /// 游戏元素的坐标
    /// </summary>
    [Game,Event(EventTarget.Self,EventType.Added,1)]
    public class ItemIndexComponent : IComponent
    {
        [EntityIndex]
        public CustomVector2 index;
    }

    /// <summary>
    /// 加载预制体组件
    /// </summary>
    [Game, Event(EventTarget.Any)]
    public class LoadPrefabComponent : IComponent
    {
        public string path;
    }


    /// <summary>
    /// 元素是否可移动的标签
    /// </summary>
    [Game]
    public class MovableComponent : IComponent
    {
        
    }

    /// <summary>
    /// 交换状态标记组件
    /// </summary>
    [Game]
    public class ExchangeComponent : IComponent
    {
        public ExchangeState exchangeState;
    }

    /// <summary>
    /// 运动状态标记组件
    /// </summary>
    [Game]
    public class MoveComplete : IComponent
    {
        
    }

    /// <summary>
    /// 获取相同颜色元素的行为标记
    /// </summary>
    [Game]
    public class GetSameColor : IComponent
    {
        
    }

    /// <summary>
    /// 保存相同颜色的数组数据
    /// </summary>
    [Game]
    public class DetectionSameItem : IComponent
    {
        public List<IEntity> _leftEntities;
        public List<IEntity> _rightEntities;
        public List<IEntity> _upEntities;
        public List<IEntity> _downEntities;
    }

    /// <summary>
    /// 判断队形，是否满足生成特殊元素的条件
    /// </summary>
    [Game]
    public class JudgeFormation : IComponent
    {
        
    }

    /// <summary>
    /// 标记是否能消除元素
    /// </summary>
    [Game]
    public class Eliminate : IComponent
    {
        public bool canEliinate;
    }

    /// <summary>
    /// 元素是否为特殊元素的标记
    /// </summary>
    [Game]
    public class ItemEffectState : IComponent
    {
        public ItemEffectName state;
    }

    /// <summary>
    /// 加载图片组件
    /// </summary>
    [Game,Event(EventTarget.Self)]
    public class LoadSprite : IComponent
    {
        public string name;
    }

    /// <summary>
    /// 分数组件
    /// </summary>
    [Game,Unique,Event(EventTarget.Any)]
    public class Score : IComponent
    {
        public int score;
    }

    /// <summary>
    /// 音效组件
    /// </summary>
    [Game,Event(EventTarget.Self)]
    public class Audio : IComponent
    {
        public string path;
    }

    /// <summary>
    /// 下落状态组件
    /// </summary>
    [Game]
    public class Fall : IComponent
    {
        public FallState state;
    }
}
