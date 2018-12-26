using UnityEngine;

public class GameManagerTurn : StateMachineBehaviour {
	internal GameManager gameManager;
	
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		gameManager.OnGameManagerTurnEnter();
	}
}