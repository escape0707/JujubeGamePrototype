using UnityEngine;

public class AIPlayer : MonoBehaviour {
	private JujubeBoard jujubeBoard;
	private bool[, , ] win;
	private int[, , ][] move;

	internal JujubeBoard JujubeBoard {
		set {
			jujubeBoard = value;
		}
	}

	internal void OnAITurnEnter() { }

	internal void OnAITurnExit() { }

	private void FindAnswer(int first, int second, int third) { // 'c' for "counts".
		int[] c = { first, second, third };
		for (int i = 0; i < 3; ++i) {
			int tmp = c[i];
			while (--c[i] >= 0) {
				if (win[c[0], c[1], c[2]] == false) {
					win[first, second, third] = true;
					// move = new - old. So old + move = new!
					move[first, second, third] = new int[] { i, c[i] - tmp };
					return;
				}
			}
			c[i] = tmp;
		}
		win[first, second, third] = false;
	}

	// Currently only consider 3-pile-condition.
	private void DynamicProgramming() {
		int[] piles = jujubeBoard.MaxCountForGroups;
		int a = piles[0];
		int b = piles[1];
		int c = piles[2];
		// Note that because empty is also a valid state. So there are maxCount + 1 states to store.
		move = new int[a + 1, b + 1, c + 1][];
		win = new bool[a + 1, b + 1, c + 1];
		win[0, 0, 0] = true;

		// No need to cut branches in such a small data-range.
		// Only do that if you cares (like me) a feasible region constrained by seven planes altogether in three dimensions.
		// So just doing necessary sanity check is enough.
		int max = a + b + c;
		for (int total = 1; total <= max; ++total) {
			for (int first = 0; first <= a; ++first) {
				for (int second = 0; second <= b; ++second) {
					int third = total - first - second;
					if (0 <= third && third <= c) {
						FindAnswer(first, second, third);
					} // else ?? Really don't want to cut branches??
				}
			}
		}
	}

	void Start() {
		DynamicProgramming();
	}
}