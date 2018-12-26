using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	[SerializeField]
	private readonly int PlayersCount = 2;

	private Animator animator;
	private JujubeBoard jujubeBoard;
	private AIPlayer aIPlayer;
	private Text gameOverText;

	private GameManagerTurn gameManagerTurn;
	private PlayerTurn playerTurn;
	private AITurn aITurn;

	void Awake() {
		animator = GetComponent<Animator>();
		jujubeBoard = GameObject.FindWithTag("JujubeBoard").GetComponent<JujubeBoard>();
		aIPlayer = GameObject.FindWithTag("AIPlayer").GetComponent<AIPlayer>();
		aIPlayer.JujubeBoard = jujubeBoard;
		gameOverText = GameObject.FindWithTag("GameOverText").GetComponent<Text>();
	}

	void Start() {
		gameManagerTurn = animator.GetBehaviour<GameManagerTurn>();
		gameManagerTurn.gameManager = this;
		playerTurn = animator.GetBehaviour<PlayerTurn>();
		playerTurn.jujubeBoard = jujubeBoard;
		aITurn = animator.GetBehaviour<AITurn>();
		aITurn.aIPlayer = aIPlayer;
	}

	internal void OnGameManagerTurnEnter() {
		if (jujubeBoard.CheckGameOver()) {
			gameOverText.enabled = true;
			animator.SetTrigger("GameOverTrigger");
		} else {
			int nextPlayerID = animator.GetInteger("NextPlayerID");
			nextPlayerID = (nextPlayerID + 1) % PlayersCount;
			animator.SetTrigger("NextPlayerTrigger");
		}
	}
}