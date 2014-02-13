using System;
using System.Collections.Generic;
using System.Reflection;
using ATMTECH.DAO;
using ATMTECH.Entities;
using ATMTECH.Exception;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace ATMTECH.Web
{
    public class PresenterInterceptorException : IInterceptionBehavior
    {
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            if (input.MethodBase.DeclaringType.Name.Contains("Presenter"))
            {
                IMethodReturn result = getNext()(input, getNext);
                if (result.Exception != null)
                {
                    ManageException(input, result);
                }
                return result;
            }
            else
            {
                return getNext()(input, getNext);
            }
        }

        private void ManageException(IMethodInvocation input, IMethodReturn result)
        {
            try
            {

                if (result.Exception is BaseException)
                {
                    // Ne pas logger l'erreur elle est fait quand on appel le message
                    CallShowMessage(input.Target, (BaseException)result.Exception);
                }
                else
                {
                    string message = result.Exception.Message;
                    Message messageEx = new Message() { Description = message };
                    BaseException exception = new BaseException(messageEx);
                    LogException logException = new LogException()
                                                    {
                                                        Description = message + " => PresenterInterceptor",
                                                        InnerId = "INTERNAL",
                                                        Page =
                                                            Utils.Web.Pages.GetCurrentUrl() +
                                                            Utils.Web.Pages.GetCurrentPage(),
                                                        StackTrace = result.Exception.StackTrace
                                                    };
                    DAOLogException daoLogException = new DAOLogException();
                    daoLogException.Save(logException);

                    CallShowMessage(input.Target, exception);
                }
            }
            catch (BaseException exception)
            {
                //  throw exceptionLog;
            }

            result.Exception = null;
        }


        private void CallShowMessage(object instancePresenter, BaseException exception)
        {
            Type typePresenter = instancePresenter.GetType();
            PropertyInfo typeInstanceView = typePresenter.GetProperty("View");

            object instanceView = typeInstanceView.GetValue(instancePresenter, null);
            Type typeView = instanceView.GetType();

            MethodInfo methode = typeView.GetMethod("ShowMessage", new[] { typeof(Message) });
            if (methode != null)
            {
                Message message = new Message() { InnerId = exception.InnerId, Description = exception.DisplayMessage, MessageType = exception.MessageType };
                methode.Invoke(instanceView, new object[] { message });
            }
            else
            {
                throw exception;
            }
        }


        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public bool WillExecute
        {
            get { return true; }
        }
    }
}
