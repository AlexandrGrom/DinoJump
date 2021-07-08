using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.UI
{
	public class UIManager : MonoBehaviour
	{
		private Dictionary<GameState, UIScreen> screens;

		private void Awake()
		{
			List<UIScreen> screensList = GetComponentsInChildren<UIScreen>(true).ToList();
			screens = screensList.ToDictionary(screen => screen.State, screen => screen);

			GameStateManager.OnGameStateChange += HandleGameStateChange;

			GameStateManager.CurrentState = GameState.Menu;
		}

		private void HandleGameStateChange(GameState gameState)
		{
			if (screens.ContainsKey(gameState))
			{
				foreach (KeyValuePair<GameState, UIScreen> screen in screens)
				{
					screen.Value.gameObject.SetActive(false);
				}

				screens[gameState].gameObject.SetActive(true);
			}
		}

		private void OnDestroy()
		{
			GameStateManager.OnGameStateChange -= HandleGameStateChange;
		}
	}
}