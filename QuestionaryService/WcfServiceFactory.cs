
using Questionary.DAL;
using Unity;
using Unity.Wcf;

namespace QuestionaryService1
{
	public class WcfServiceFactory : UnityServiceHostFactory
    {
        protected override void ConfigureContainer(IUnityContainer container)
        {
            container.RegisterType<IRepository, Repository>().RegisterType<IQuestionaryService, QuestionaryService>();
        }
    }    
} 