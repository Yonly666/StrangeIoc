using strange.extensions.command.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo1
{
    public class UpdateScoreCommand : EventCommand
    {
        [Inject]
        public IScoreService scoreService { get; set; }

        [Inject]
        public ScoreModel scoreModel { get; set; }

        public override void Execute()
        {
            //model层数据改变
            scoreModel.Score++;

            //service层更新数据
            scoreService.UpdateScore("http://baidu.com", scoreModel.Score);

            //mediator层更新数据
            dispatcher.Dispatch(MediatorEvent.ScoreChange, scoreModel.Score);
        }

        
    }
}
