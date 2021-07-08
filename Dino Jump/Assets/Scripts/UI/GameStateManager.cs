using System;

namespace Scripts.UI
{
	public static class GameStateManager
	{
		private static GameState currentState;

		public static Action<GameState> OnGameStateChange;

		public static GameState CurrentState
		{
			get => currentState;

			set	{
				if (currentState == value) return;
				
				currentState = value;
				OnGameStateChange?.Invoke(currentState);
			}
		}
	}
}