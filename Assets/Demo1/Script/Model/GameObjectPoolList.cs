using UnityEngine;
using System.Collections.Generic;

namespace Demo1
{
    public class GameObjectPoolList : ScriptableObject
    {
        public List<GameObjectPool> poolList = new List<GameObjectPool>();
    }
}
