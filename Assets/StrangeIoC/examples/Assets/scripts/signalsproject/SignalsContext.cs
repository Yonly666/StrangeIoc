/// If you're new to Strange, start with MyFirstProject.
/// If you're interested in how Signals work, return here once you understand the
/// rest of Strange. This example shows how Signals differ from the default
/// EventDispatcher.
/// All comments from MyFirstProjectContext have been removed and replaced by comments focusing
/// on the differences 

using System;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;

namespace strange.examples.signals
{
	public class SignalsContext : MVCSContext
	{
        /// <summary>
        /// 构造方法，在root中创建对象
        /// </summary>
        /// <param name="view"></param>
		public SignalsContext (MonoBehaviour view) : base(view)
		{
		}

		public SignalsContext (MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
		{
		}
		
		// Unbind the default EventCommandBinder and rebind the SignalCommandBinder
		protected override void addCoreComponents()
		{
			base.addCoreComponents();
			injectionBinder.Unbind<ICommandBinder>();
			injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
		}
		
		// Override Start so that we can fire the StartSignal 
		override public IContext Start()
		{
			base.Start();
			StartSignal startSignal= (StartSignal)injectionBinder.GetInstance<StartSignal>();
			startSignal.Dispatch();
			return this;
		}
		
        /// <summary>
        /// 绑定
        /// </summary>
		protected override void mapBindings()
		{
            // injectionBinder  注入绑定
            // mediationBinder  中间层绑定
            // commandBinder    命令绑定

            //model
            injectionBinder.Bind<IExampleModel>().To<ExampleModel>().ToSingleton();
            //service
            injectionBinder.Bind<IExampleService>().To<ExampleService>().ToSingleton();
			
            //view
			mediationBinder.Bind<ExampleView>().To<ExampleMediator>();
			
            //command
			commandBinder.Bind<CallWebServiceSignal>().To<CallWebServiceCommand>();

            //StartSignal is now fired instead of the START event.
            //启动信号现在被触发，而不是开始事件。
            //Note how we've bound it "Once". This means that the mapping goes away as soon as the command fires.
            //请注意我们是如何将它绑定到“Once”的。这意味着一旦命令触发，映射就会消失
            commandBinder.Bind<StartSignal>().To<StartCommand>().Once ();

            //In MyFirstProject, there's are SCORE_CHANGE and FULFILL_SERVICE_REQUEST Events.
            //在MyFirstProject中，有计分和实现服务请求事件。
            //Here we change that to a Signal. The Signal isn't bound to any Command,
            //这里我们把它变成一个信号。信号不受任何命令的约束，
            //so we map it as an injection so a Command can fire it, and a Mediator can receive it
            //所以我们把它映射成一个注入这样一个命令就可以触发它，一个中介可以接收它
            injectionBinder.Bind<ScoreChangedSignal>().ToSingleton();
			injectionBinder.Bind<FulfillWebServiceRequestSignal>().ToSingleton();
		}
	}
}

