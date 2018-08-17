using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Demo1
{
    /// <summary>
    /// 尽量只含有 View和Command 之间的传递
    /// </summary>
    public class CubeMediator : Mediator {

        [Inject]
        public CubeView cubeView { get; set; }

        //全局的派发器
        [Inject(ContextKeys.CONTEXT_DISPATCHER)]
        public IEventDispatcher dispatcher { get; set; }

        //[Inject]
        //public ScoreModel scoreModel { get; set; }  //可以直接获取分数model来进行传值，但不建议这样做

        public override void PreRegister()  //预注册在Awake中执行（在绑定View与mediator之前注册）
        {
            
        }

        public override void OnRegister()   //注册在Awake中执行
        {
            //View初始化
            cubeView.Init();

            //监听分数改变事件
            dispatcher.AddListener(MediatorEvent.ScoreChange, OnScoreChange);
            
            //监听view层的事件
            cubeView.dispatcher.AddListener(MediatorEvent.AddScore, OnMouseDownToAddScore);

            //请求数据
            dispatcher.Dispatch(CommandEvent.RequestScore);
            Debug.Log("全局监听分数变化");
        }

        public override void OnRemove() //移除在OnDestroy中执行
        {
            //移除监听
            dispatcher.RemoveListener(MediatorEvent.ScoreChange, OnScoreChange);
            cubeView.dispatcher.RemoveListener(MediatorEvent.AddScore, OnMouseDownToAddScore);
        }

        public void OnScoreChange(IEvent evt)
        {
            //cubeView.UpdateScore(scoreModel.Score);   model层到mediator层
            cubeView.UpdateScore((int)evt.data);
        }

        public void OnMouseDownToAddScore()
        {
            //触发更新分数
            dispatcher.Dispatch(CommandEvent.UpdateScore);
        }
    }
}