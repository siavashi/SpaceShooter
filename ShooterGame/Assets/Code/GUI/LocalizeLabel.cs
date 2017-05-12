﻿using System.Collections;
using System.Collections.Generic;
using TAMKShooter.Systems;
using UnityEngine;
using UnityEngine.UI;

namespace TAMKShooter.GUI
{
	public class LocalizeLabel : MonoBehaviour
	{
		[SerializeField] private Text _text;
		[SerializeField] private string _key;

		private void Awake()
		{
			if ( _text == null )
			{
				_text = GetComponent< Text >();
			}

			Localization.LanguageLoaded += OnLanguageLoaded;
		}

		private void OnLanguageLoaded()
		{
			_text.text = Localization.CurrentLanguage.GetTranslation(_key);
		}

		private void Start()
		{
			OnLanguageLoaded();
		}
	}
}