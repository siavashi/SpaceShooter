using System;
using System.Collections.Generic;
using TAMKShooter.Data;
using TAMKShooter.GUI;
using UnityEngine;

namespace TAMKShooter.Systems
{
	public class GameOverManager : SceneManager
	{
		public override GameStateType StateType
		{
			get { return GameStateType.GameOverState; }
		}

		public void BackToMenu()
		{
			Global.Instance.GameManager.PerformTransition( GameStateTransitionType.GameOverToMenu );
		}
	}
}
