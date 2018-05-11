using DevExpress.Mvvm;

namespace Databvase_Winforms.Messages
{
    public class TabNameMessage
    {
        
        public string Name { get; set; }

        public TabNameMessage(string name)
        {
            Name = name;
            SendMessage();
        }

        private void SendMessage()
        {
            Messenger.Default.Send(this, GetType().Name);
        }
    }
}