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
        /// ���췽������root�д�������
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
        /// ��
        /// </summary>
		protected override void mapBindings()
		{
            // injectionBinder  ע���
            // mediationBinder  �м���
            // commandBinder    �����

            //model
            injectionBinder.Bind<IExampleModel>().To<ExampleModel>().ToSingleton();
            //service
            injectionBinder.Bind<IExampleService>().To<ExampleService>().ToSingleton();
			
            //view
			mediationBinder.Bind<ExampleView>().To<ExampleMediator>();
			
            //command
			commandBinder.Bind<CallWebServiceSignal>().To<CallWebServiceCommand>();

            //StartSignal is now fired instead of the START event.
            //�����ź����ڱ������������ǿ�ʼ�¼���
            //Note how we've bound it "Once". This means that the mapping goes away as soon as the command fires.
            //��ע����������ν����󶨵���Once���ġ�����ζ��һ���������ӳ��ͻ���ʧ
            commandBinder.Bind<StartSignal>().To<StartCommand>().Once ();

            //In MyFirstProject, there's are SCORE_CHANGE and FULFILL_SERVICE_REQUEST Events.
            //��MyFirstProject�У��мƷֺ�ʵ�ַ��������¼���
            //Here we change that to a Signal. The Signal isn't bound to any Command,
            //�������ǰ������һ���źš��źŲ����κ������Լ����
            //so we map it as an injection so a Command can fire it, and a Mediator can receive it
            //�������ǰ���ӳ���һ��ע������һ������Ϳ��Դ�������һ���н���Խ�����
            injectionBinder.Bind<ScoreChangedSignal>().ToSingleton();
			injectionBinder.Bind<FulfillWebServiceRequestSignal>().ToSingleton();
		}
	}
}

