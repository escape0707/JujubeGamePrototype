using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	[SerializeField]
	private JujubeBoard jujubeBoard;
	[SerializeField]
	GameObject gameOverText;

	private Animator animator;
	private GameManagerTurn gameManagerTurn;
	private PlayerTurn playerTurn;

	void Awake() {
		animator = GetComponent<Animator>();
	}

	void Start() {
		gameManagerTurn = animator.GetBehaviour<GameManagerTurn>();
		gameManagerTurn.gameManager = this;
		playerTurn = animator.GetBehaviour<PlayerTurn>();
		playerTurn.jujubeBoard = jujubeBoard;
	}

	public void Validate() {
		if (jujubeBoard.CheckGameOver()) {
			gameOverText.SetActive(true);
			animator.SetTrigger("GameOver");
		} else {
			animator.SetTrigger("PlayerTurn");
		}
	}
}