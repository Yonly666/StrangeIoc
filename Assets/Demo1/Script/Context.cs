using strange.extensions.context.api;
using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Demo1
{
    public class Context : MVCSContext
    {
        public Context(MonoBehaviour mono) : base(mono)
        {

        }

        /// <summary>
        /// 绑定
        /// </summary>
        protected override void mapBindings()
        {
            //manager
            injectionBinder.Bind<AudioManager>().To<AudioManager>().ToSingleton();

            //model（自身与自身绑定？）
            injectionBinder.Bind<ScoreModel>().To<ScoreModel>().ToSingleton();

            //service（接口与自身绑定？）
            injectionBinder.Bind<IScoreService>().To<ScoreService>().ToSingleton();

            //command（事件类型与控制类绑定）
            commandBinder.Bind(CommandEvent.RequestScore).To<RequestScoreCommand>();
            commandBinder.Bind(CommandEvent.UpdateScore).To<UpdateScoreCommand>();

            //mediator（View与Mediator绑定）
            mediationBinder.Bind<CubeView>().To<CubeMediator>();


            //绑定开始事件一个startcommand(只绑定一次，再触发就解绑了)，用于启动程序
            commandBinder.Bind(ContextEvent.START).To<StartCommand>().Once();

        }
    }
}