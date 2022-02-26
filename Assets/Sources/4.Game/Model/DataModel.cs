﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [Serializable]
    public class DataModel
    {
        public List<Item> Level;
    }

    [Serializable]
    public class Item
    {
        public List<int> row_0;
        public List<int> row_1;
        public List<int> row_2;
        public List<int> row_3;
        public List<int> row_4;
        public List<int> row_5;
        public List<int> row_6;
        public List<int> row_7;
        public List<int> row_8;
    }
}

