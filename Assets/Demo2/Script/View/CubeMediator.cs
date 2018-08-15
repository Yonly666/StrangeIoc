using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Demo2
{
    public class CubeMediator : Mediator
    {
        [Inject]
        public CubeView cubeView { get; set; }

        [Inject(ContextKeys.CONTEXT_DISPATCHER)]
        public IEventDispatcher dispatcher { get; set; }

        public override void OnRegister()
        {
            cubeView.Init();
            cubeView.dispatcher.AddListener(MediatorEvent.AddScore, AddScore);
            dispatcher.AddListener(MediatorEvent.UpdateScore, ScoreChange);
            dispatcher.Dispatch(CommandEvent.RequestScore);
        }

        public override void OnRemove()
        {
            cubeView.dispatcher.RemoveListener(MediatorEvent.AddScore, AddScore);
            dispatcher.RemoveListener(MediatorEvent.UpdateScore, ScoreChange);
        }

        void AddScore()
        {
            dispatcher.Dispatch(CommandEvent.UpdateScore);
        }

        void ScoreChange(IEvent evt)
        {
            cubeView.UpdateScore((int)evt.data);
        }
    }
}
