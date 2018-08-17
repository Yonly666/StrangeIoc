using UnityEngine;
using System.Collections.Generic;

namespace Demo1
{
    [System.Serializable]
    public class GameObjectPool : ScriptableObject
    {
        public string name;

        [SerializeField]
        private GameObject prefab;

        [SerializeField]
        private float maxValue;

        private List<GameObject> objList;


        public GameObject GetInstance()
        {
            foreach (var obj in objList)
            {
                if (obj.activeInHierarchy == false)
                {
                    obj.SetActive(true);
                    return obj;
                }
            }
            GameObject objTemp = GameObject.Instantiate(prefab);
            objList.Add(objTemp);
            return objTemp;
        }
    }
}
