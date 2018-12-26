using UnityEngine;
using UnityEngine.UI;

public class AIPlayer : MonoBehaviour {
	[SerializeField]
	private JujubeBoard jujubeBoard;
	[SerializeField]
	GameObject gameOverText;

	private Animator animator;
	private AITurn _AITurn;

	void Awake() {
		animator = GetComponent<Animator>();
	}

	void Start() {
		_AITurn = animator.GetBehaviour<AITurn>();
		AITurn.AIScript = this;
	}

	public void Validate() {
		if (jujubeBoard.CheckGameOver()) {
			gameOverText.SetActive(true);
		} else {
			int nextPlayerID = animator.GetInteger("NextPlayerID");
			nextPlayerID ^= 1;
			animator.SetInteger("NextPlayerID", nextPlayerID);
			animator.SetTrigger("NextPlayerTrigger");
		}
	}
}