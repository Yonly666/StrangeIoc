using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using UnityEngine;

namespace Demo2
{
    public class RequestScoreCommand : EventCommand
    {
        [Inject]
        public ScoreModel scoreModel { get; set; }

        [Inject]
        public IScoreService scoreService { get; set; }

        public override void Execute()
        {
            Retain();
            scoreService.dispatcher.AddListener(ServiceEvent.RequestScore, OnComplete);

            scoreService.RequestScore("http://baidu.com");
        }


        void OnComplete(IEvent evt)
        {
            scoreModel.score = (int)evt.data;
            scoreService.dispatcher.RemoveListener(ServiceEvent.RequestScore, OnComplete);
            dispatcher.Dispatch(MediatorEvent.UpdateScore, evt.data);
            Release();
        }
    }
}
