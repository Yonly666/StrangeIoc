using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Demo1 {
    public class GameObjectPoolListEditor : Editor {


        private static string savePath = "Assets\\Demo1\\Resources\\GameObjectPoolList.asset";

        [MenuItem("Manager/GameObjectPoolList")]
        static void GameObjectPoolList()
        {
            ScriptableObject objPool = CreateInstance(typeof(Demo1.GameObjectPoolList));

            AssetDatabase.CreateAsset(objPool, savePath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}