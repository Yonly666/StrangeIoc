using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Demo1
{
    public class RequestScoreCommand : EventCommand //自动得到全局的派发器
    {
        [Inject]
        public IScoreService scoreService { get; set; }

        [Inject]
        public ScoreModel scoreModel { get; set; }

        public override void Execute()
        {
            Retain();   //保持此监听在没有执行前不被跳过，等待服务器需要时间
            //服务器监听请求完毕事件
            scoreService.dispatcher.AddListener(ServiceEvent.RequestScore, OnComplete);

            //服务器请求数据
            scoreService.RequestScore("https://baidu.com");
        }

        public void OnComplete(IEvent evt)
        {
            Debug.Log("request score complete , score is " + evt.data);
            scoreService.dispatcher.RemoveListener(ServiceEvent.RequestScore, OnComplete);
            //为model层赋值
            scoreModel.Score = (int)evt.data;
            //给中间层传递信息
            dispatcher.Dispatch(MediatorEvent.ScoreChange, evt.data);
            //释放保持功能
            Release();
        }
    }
}
