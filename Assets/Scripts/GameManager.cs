using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	[SerializeField]
	private JujubeBoard jujubeBoard;
	[SerializeField]
	GameObject gameOverText;

	private Animator animator;
	private GameManagerTurn gameManagerTurn;

	void Awake() {
		animator = GetComponent<Animator>();
	}

	void Start() {
		gameManagerTurn = animator.GetBehaviour<GameManagerTurn>();
		gameManagerTurn.gameManager = this;
	}

	public void Validate() {
		if (jujubeBoard.CheckGameOver()) {
			gameOverText.SetActive(true);
		}
	}
}