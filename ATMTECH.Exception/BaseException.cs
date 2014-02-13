using ATMTECH.Entities;

namespace ATMTECH.Exception
{
    public class BaseException : System.Exception
    {
        public string DisplayMessage { get; set; }
        public string InnerId { get; set; }
        public string MessageType { get; set; }
       
        public BaseException(Message message)
        {
            DisplayMessage = message.Description;
            InnerId = message.InnerId;
            MessageType = message.MessageType;
        }

        public BaseException(string text)
        {
            DisplayMessage = text;
            InnerId = "XXX-001";
        }

      
    }
}
