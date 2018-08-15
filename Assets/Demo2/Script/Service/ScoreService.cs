using strange.extensions.dispatcher.eventdispatcher.api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Demo2
{
    public class ScoreService : IScoreService
    {
        public void OnReceiveScore()
        {
            int score = Random.Range(0, 101);
            dispatcher.Dispatch(ServiceEvent.RequestScore, score);
        }

        public void RequestScore(string url)
        {
            Debug.Log("请求数据 url:" + url);
            OnReceiveScore();
        }

        public void UpdateScore(string url, int score)
        {
            Debug.Log("更新数据 url:" + url + " score:" + score);
        }

        [Inject]
        public IEventDispatcher dispatcher { get; set; }
    }
}