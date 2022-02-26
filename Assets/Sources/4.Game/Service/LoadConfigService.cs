using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 加载配置服务
    /// </summary>
    public class LoadConfigService
    {
        public static LoadConfigService Instance { get; private set; } = new LoadConfigService();

        public T LoadJson<T>() where T:class 
        {
            if (File.Exists(ResPath.DataPath))
            {
                string json = File.ReadAllText(ResPath.DataPath);
                return JsonUtility.FromJson<T>(json);
            }

            return null;
        }
    }
}

