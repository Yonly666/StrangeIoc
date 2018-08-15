using strange.extensions.context.api;
using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Demo2
{
    public class Context : MVCSContext
    {

        public Context(MonoBehaviour mono):base(mono)
        {
            
        }

        protected override void mapBindings()
        {
            //model
            injectionBinder.Bind<ScoreModel>().To<ScoreModel>().ToSingleton();
            //service
            injectionBinder.Bind<IScoreService>().To<ScoreService>().ToSingleton();
            //command
            commandBinder.Bind(CommandEvent.RequestScore).To<RequestScoreCommand>();
            commandBinder.Bind(CommandEvent.UpdateScore).To<UpdateScoreCommand>();

            //mediator
            mediationBinder.Bind<CubeView>().To<CubeMediator>();
            //start
            commandBinder.Bind(ContextEvent.START).To<StartCommand>().Once();
        }
    }
}