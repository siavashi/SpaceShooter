using System.IO;
using TAMKShooter.Systems;

namespace TAMKShooter.Exceptions
{
	public class LocalizationNotFoundException : FileNotFoundException
	{
		public LangCode Language { get; private set; }

		public LocalizationNotFoundException( LangCode language )
		{
			Language = language;
		}

		public override string Message
		{
			get { return "Localization can not be found for language " + Language; }
		}
	}
}