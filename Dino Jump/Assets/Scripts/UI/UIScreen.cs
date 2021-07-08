using UnityEngine;

namespace Scripts.UI
{
	public class UIScreen : MonoBehaviour
	{
		[SerializeField] protected GameState state;
		public GameState State => state;
	}
}