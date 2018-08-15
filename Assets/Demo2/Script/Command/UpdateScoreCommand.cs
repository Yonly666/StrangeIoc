using strange.extensions.command.impl;
using UnityEngine;

namespace Demo2
{
    public class UpdateScoreCommand : EventCommand
    {
        [Inject]
        public ScoreModel scoreModel { get; set; }

        [Inject]
        public IScoreService scoreService { get; set; }


        public override void Execute()
        {
            scoreModel.score++;

            scoreService.UpdateScore("http://baidu.com", scoreModel.score);

            dispatcher.Dispatch(MediatorEvent.UpdateScore, scoreModel.score);
        }
    }
}
