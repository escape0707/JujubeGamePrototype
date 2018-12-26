using UnityEngine;

public class AITurn : StateMachineBehaviour {
	internal AIPlayer aIPlayer;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		aIPlayer.OnAITurnEnter();
		animator.SetTrigger("AIMovedTrigger");
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		aIPlayer.OnAITurnExit();
	}
}