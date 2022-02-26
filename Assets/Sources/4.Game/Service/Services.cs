using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 初始化所有service
    /// </summary>
    public class Services
    {
        public Services(Contexts contexts,Transform gameController)
        {
            LoadPrefabService.Instance.Init(contexts, gameController);
            CreaterService.Instance.Init(contexts);
            GetEmptyItemService.Instance.Init(contexts);
        }
    }

}

