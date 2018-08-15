using strange.extensions.dispatcher.eventdispatcher.api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Demo1
{
    public interface IScoreService
    {
        IEventDispatcher dispatcher { get; set; }

        void RequestScore(string url);

        int OnReceiveScore();

        void UpdateScore(string url, int score);
    }
}