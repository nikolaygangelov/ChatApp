namespace ChatApp.Models.Messsge
{
	/// <summary>
	/// substitute of database
	/// </summary>
	public class ChatViewModel
	{
		public MessageViewModel CurrentMessage { get; set; } = null!;

		/// <summary>
		/// the already created messages, which will be passed to and displayed by the view
		/// </summary>
		public List<MessageViewModel> Messages { get; set; } = null!; 
	}
}
