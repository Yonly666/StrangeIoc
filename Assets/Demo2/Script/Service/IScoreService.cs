using strange.extensions.dispatcher.eventdispatcher.api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Demo2
{
    public interface IScoreService 
    {
        void RequestScore(string url);

        void OnReceiveScore();

        void UpdateScore(string url, int score);

        IEventDispatcher dispatcher { get; set; }
    }
}