using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class JujubeGroup : MonoBehaviour {
	[SerializeField]
	private GameObject JujubePrefab;

	private int maxForGroup;
	private int jujubeCount;
	private int previousCount; // TODO!! Not maintained.
	private JujubeBoard jujubeBoard;
	private CanvasGroup canvasGroup;
	private List<JujubeToggle> jujubes = new List<JujubeToggle>();

	// Interesting.. I choosed to let others tell me the info here.
	internal int MaxForGroup {
		set {
			maxForGroup = value;
		}
	}

	internal bool IsEmpty {
		get {
			return jujubeCount == 0;
		}
	}

	internal void NewTurn() {
		previousCount = jujubeCount;
		for (int count = 0; count < maxForGroup; ++count) {
			bool isRemained = count < previousCount;
			jujubes[count].isOn = isRemained;
			jujubes[count].gameObject.SetActive(isRemained);
		}
	}

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
	}

	void Start() {
		// Interesting.. Tried to Instantiate() in Awake(). But maxForGroup is not assigned at that phase. But I have done that immediately after the instantiation of this GameObject?
		for (jujubeCount = 0; jujubeCount < maxForGroup; ++jujubeCount) {
			GameObject child = Instantiate(JujubePrefab, transform);
			jujubes.Add(child.GetComponent<JujubeToggle>());
		}
	}
}