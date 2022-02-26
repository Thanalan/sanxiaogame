using Entitas;

namespace HelloWorld
{
    /// <summary>
    /// 打印消息组件
    /// </summary>
    [Game]
    public class LogComponent : IComponent
    {
        /// <summary>
        /// 打印信息
        /// </summary>
        public string message;
    }
}


