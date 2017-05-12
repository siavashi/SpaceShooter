using System.Collections.Generic;
using TAMKShooter.Systems;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;

public class LanguageWindow : EditorWindow
{
	[MenuItem("Localization/Edit")]
	static void OpenWindow()
	{
		LanguageWindow window = GetWindow< LanguageWindow >();
		window.Show();
	}

	private const string LocalizationKey = "Localization";

	public LangCode LanguageCode = LangCode.NA;

	private Language _currentLanguage;
	private Dictionary<string, string> _localizations =
		new Dictionary< string, string >();

	private void OnEnable()
	{
		string language = EditorPrefs.GetString( LocalizationKey, LangCode.NA.ToString() );
		LangCode langCode = (LangCode) Enum.Parse( typeof( LangCode ), language );
		SetLanguage( langCode );
	}

	private void OnGUI()
	{
		LangCode langCode = (LangCode)EditorGUILayout.EnumPopup( LanguageCode );
		SetLanguage( langCode );

		EditorGUILayout.BeginVertical();

		Dictionary<string, string> newValues = new Dictionary< string, string >();
		List<string> deletedKeys = new List< string >();
		foreach ( var localization in _localizations )
		{
			EditorGUILayout.BeginHorizontal();

			string key = EditorGUILayout.TextField( localization.Key );
			string value = EditorGUILayout.TextField( localization.Value );

			newValues.Add( key, value );

			if ( GUILayout.Button( "X" ) )
			{
				deletedKeys.Add(localization.Key);
			}

			EditorGUILayout.EndHorizontal();
		}

		_localizations = newValues;
		foreach ( var deletedKey in deletedKeys )
		{
			if ( _localizations.ContainsKey( deletedKey ) )
			{
				_localizations.Remove( deletedKey );
			}
		}

		if ( GUILayout.Button( "Add value" ) )
		{
			if ( !_localizations.ContainsKey( "" ) )
			{
				_localizations.Add( "", "" );
			}
		}

		if ( GUILayout.Button( "Save" ) )
		{
			Localization.CurrentLanguage.SetValues( _localizations );
			Localization.SaveCurrentLanguage();
		}

		EditorGUILayout.EndVertical();
	}

	private void SetLanguage( LangCode langCode )
	{
		if ( LanguageCode != langCode )
		{
			LanguageCode = langCode;
			EditorPrefs.SetString( LocalizationKey, LanguageCode.ToString() );
			_localizations.Clear();

			string path = Localization.GetLocalizationFilePath( langCode );
			if ( File.Exists( path ) )
			{
				Localization.LoadLanguage( langCode );
				_localizations = Localization.CurrentLanguage.GetValues();
			}
			else
			{
				Localization.CreateNewLanguage( langCode );
			}
		}
	}
}