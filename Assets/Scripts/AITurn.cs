using UnityEngine;

public class AITurn : StateMachineBehaviour {
	internal AIPlayer aIPlayer;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		aIPlayer.OnAITurnEnter();
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		aIPlayer.OnAITurnExit();
	}
}