using ChatApp.Models.Messsge;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
	public class ChatController : Controller
	{
		/// <summary>
		/// there is no database, that is why this private field is located here
		/// a collection of messages, which has the message sender as key and the message text as value
		/// does not allow duplicate keys
		/// </summary>
		private static List<KeyValuePair<string, string>> s_messages 
			= new List<KeyValuePair<string, string>>();

		/// <summary>
		/// passes the current messages (if any) to a view as a model
		/// </summary>
		/// <returns>
		/// View(chatModel) which displays the messages (if they exist)
		/// </returns>
		public IActionResult Show()
		{
			if (s_messages.Count < 1)
			{
				return View(new ChatViewModel ());
			}

			var chatModel = new ChatViewModel()
			{
				Messages = s_messages.Select(m => new MessageViewModel()
				{
					Sender = m.Key,
					MessageText = m.Value
				}).ToList()
			};

			return View(chatModel);
        }


		/// <summary>
		/// accepts the model and adds a new message with the model data to the other messages
		/// </summary>
		/// <param name="chat"></param>
		/// <returns>action "Show" by redirection, which again passes all messages to the view (including the new one)</returns>
		[HttpPost] //sending data to server; action will be invoked on a "POST" request to "/Chat/Send"
		public IActionResult Send(ChatViewModel chat)
		{
			var newMessage = chat.CurrentMessage;

			s_messages.Add(new KeyValuePair<string, string>
				(newMessage.Sender, newMessage.MessageText));

			return RedirectToAction("Show");
		}


	}
}
