using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SortePerWpf
{
    class LogMessage
    {
		
		private SolidColorBrush colorOfMessage;

		public SolidColorBrush ColorOfMessage
		{
			get { return colorOfMessage; }
			set { colorOfMessage = value; }
		}

		private string message;

		public string Message
		{
			get { return message; }
			set { message = value; }
		}

		

		private string messageTime;

		public string MessageTime
		{
			get { return messageTime; }
			set { messageTime = value; }
		}



		public LogMessage(string message)
		{
			this.Message = message;
		}



	}
}
