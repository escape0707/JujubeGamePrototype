using UnityEngine;

public class GameManager : MonoBehaviour {
	[SerializeField]
	private readonly int PlayersCount = 2;

	private Animator animator;
	private JujubeBoard jujubeBoard;
	private GameObject gameOverText;

	private GameManagerTurn gameManagerTurn;
	private PlayerTurn playerTurn;
	private AITurn aITurn;

	void Awake() {
		animator = GetComponent<Animator>();
		jujubeBoard = GameObject.FindWithTag("JujubeBoard").GetComponent<JujubeBoard>();
		gameOverText = GameObject.FindWithTag("GameOver");
	}

	void Start() {
		gameManagerTurn = animator.GetBehaviour<GameManagerTurn>();
		gameManagerTurn.gameManager = this;
		playerTurn = animator.GetBehaviour<PlayerTurn>();
		playerTurn.jujubeBoard = jujubeBoard;
		aITurn = animator.GetBehaviour<AITurn>();
		aITurn.aIPlayer = GameObject.FindWithTag("AIPlayer").GetComponent<AIPlayer>();
		aITurn.aIPlayer.JujubeBoard = jujubeBoard;
	}

	internal void OnGameManagerTurnEnter() {
		if (jujubeBoard.CheckGameOver()) {
			gameOverText.SetActive(true);
			animator.SetTrigger("GameOverTrigger");
		} else {
			int nextPlayerID = animator.GetInteger("NextPlayerID");
			nextPlayerID = (nextPlayerID + 1) % PlayersCount;
			animator.SetTrigger("NextPlayerTrigger");
		}
	}
}