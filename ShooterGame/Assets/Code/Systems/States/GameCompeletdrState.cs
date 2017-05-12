using TAMKShooter.Configs;

namespace TAMKShooter.Systems.States
{
	public class GameCompeletedState : GameStateBase
	{
		public override string SceneName
		{
			get { return Config.GameCompeletedName; }
		}

		public GameCompeletedState()
		{
			State = GameStateType.GameCompeletedState;
			AddTransition( GameStateTransitionType.InGameToMenu , GameStateType.GameCompeletedState);
		}
	}
}