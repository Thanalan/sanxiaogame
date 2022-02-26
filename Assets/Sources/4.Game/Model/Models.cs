using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 初始化所有数据类
    /// </summary>
    public class Models
    {
        public static Models Instance { get; private set; } = new Models();

        /// <summary>
        /// 场景配置文件
        /// </summary>
        public DataModel DataModel { get; private set; }

        public void Init()
        {
            DataModel = LoadConfigService.Instance.LoadJson<DataModel>();
        }
    }

}

