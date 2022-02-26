using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class RandomPathService
    {
        public static string RandomPath()
        {
            int index = Random.Range(0, 6);

            return "Item" + index;
        }
    }

}

