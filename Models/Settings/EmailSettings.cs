namespace Options.Models.Settings {
	public class EmailSettings {
		public string Smtp { get; set; }

		public int Port { get; set; }

		public string User { get; set; }

		public string Pwd { get; set; }

		public string Sender { get; set; }

		//public List<string> Whitelist { get; set; }

		public string WhitelistStr {
			get {
				return string.Join("|", Whitelist ?? new List<string>());
			}
			set {
				Whitelist = value.Split('|').ToList();
			}
		}
		public List<string> Whitelist { get; set; }
	}
}
