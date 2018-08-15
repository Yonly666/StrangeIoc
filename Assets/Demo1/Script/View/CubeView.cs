using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Demo1
{
    public class CubeView : View
    {
        //局部的派发器
        [Inject]
        public IEventDispatcher dispatcher { get; set; }

        private Text cubeText;

        public void Init()
        {
            cubeText = GetComponentInChildren<Text>();
            Debug.Log("init complete!");
        }

        private void Update()
        {
            transform.Translate(new Vector3(Random.Range(-1f, 2f), Random.Range(-1f, 2f), Random.Range(-1f, 2f)) * Time.deltaTime);
        }

        //点击模型
        public void OnMouseDown()
        {
            Debug.Log("on mouse down");
            //执行加分事件
            dispatcher.Dispatch(MediatorEvent.AddScore);
        }

        //更新分数
        public void UpdateScore(int score)
        {
            cubeText.text = score.ToString();
        }
    }
}