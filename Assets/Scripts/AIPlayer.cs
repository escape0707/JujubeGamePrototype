using UnityEngine;

public class AIPlayer : MonoBehaviour {
	private JujubeBoard jujubeBoard;

	internal JujubeBoard JujubeBoard {
		set {
			jujubeBoard = value;
		}
	}

	internal void OnAITurnEnter() { }

	internal void OnAITurnExit() { }
}