using UnityEngine;
using UnityEngine.Assertions;

public class JujubeGroup : MonoBehaviour {
	[SerializeField]
	private GameObject JujubePrefab;

	[SerializeField]
	private int maxForGroup; // TODO
	private int jujubeCount;
	private int previousCount; // TODO!! Not maintained.
	private JujubeBoard jujubeBoard;
	private CanvasGroup canvasGroup;

	internal void PickOne() {
		if (jujubeCount-- == previousCount) {
			jujubeBoard.MakeOtherGroupsNotInteractable(canvasGroup);
		}

		Assert.IsTrue(jujubeCount >= 0, "Jujube count for this group goes to negative");
	}

	internal void UnpickOne() {
		if (++jujubeCount == previousCount) {
			jujubeBoard.MakeAllGroupsInteractable();
		}

		Assert.IsTrue(jujubeCount <= maxForGroup, "Jujube count for this group exceeded its max");
	}

	void Awake() {
		jujubeBoard = GetComponentInParent<JujubeBoard>();
		canvasGroup = GetComponent<CanvasGroup>();

		for (jujubeCount = 0; jujubeCount < maxForGroup; ++jujubeCount) {
			Instantiate(JujubePrefab, transform);
		}
		// previousCount = jujubeCount;
	}
}