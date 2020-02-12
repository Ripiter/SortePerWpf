using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SortePerWpf
{
    enum MessageType
    {
        playerRemoved,
        cardMatch,
        playersTurn
    }
    static class Log
    {
        public static ObservableCollection<LogMessage> logs = new ObservableCollection<LogMessage>();

        static Color color;
        public static void AddToLog(LogMessage logMessage, MessageType type)
        {
            GetColor(type);
            logMessage.ColorOfMessage = new SolidColorBrush(color);
            logMessage.MessageTime = DateTime.Now.ToString();
            logs.Insert(0,logMessage);
        }

        static void GetColor(MessageType type)
        {
            switch (type)
            {
                case MessageType.playerRemoved:
                    color = Colors.Red;
                    break;
                case MessageType.cardMatch:
                    color = Colors.Blue;
                    break;
                case MessageType.playersTurn:
                    color = Colors.Green;
                    break;
                default:
                    break;
            }
        }

    }
}
