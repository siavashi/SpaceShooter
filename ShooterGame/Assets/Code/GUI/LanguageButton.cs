using TAMKShooter.Systems;
using UnityEngine;

namespace TAMKShooter.GUI
{
	public class LanguageButton : MonoBehaviour
	{
		[SerializeField] private LangCode _language;

		public void OnClick()
		{
			Localization.LoadLanguage(_language);
		}
	}
}