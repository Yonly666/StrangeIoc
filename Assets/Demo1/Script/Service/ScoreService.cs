using strange.extensions.dispatcher.eventdispatcher.api;
using UnityEngine;

namespace Demo1
{
    public class ScoreService : IScoreService
    {
        [Inject]
        public IEventDispatcher dispatcher { get; set; }

        public void RequestScore(string url)
        {
            Debug.Log("RequestScore  url : " + url);
            Debug.Log("OnDependScore  score : " + OnReceiveScore());
            OnReceiveScore();
        }

        public int OnReceiveScore()
        {
            int score = Random.Range(0, 101);
            dispatcher.Dispatch(ServiceEvent.RequestScore, score);
            Debug.Log("on receive score :" + score);
            return score;
        }

        public void UpdateScore(string url, int score)
        {
            Debug.Log("update score  url : " + url + " score : " + score);
        }
    }
}