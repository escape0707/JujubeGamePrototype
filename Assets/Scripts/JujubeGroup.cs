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

	private void CleanUpJujubes() {
		for (int count = 0; count < maxForGroup; ++count) {
			bool isRemained = count < jujubeCount;
			jujubes[count].isOn = isRemained;
			jujubes[count].gameObject.SetActive(isRemained);
		}
	}

	internal void OnNewTurn() {
		previousCount = jujubeCount;
		CleanUpJujubes(); // Interesting.. Maybe not necessary but a rather safe thing to do?
	}

	internal void OnEndTurn() {
		CleanUpJujubes(); // Interesting.. This is the earliest place were we should do it.
	}

	internal void PickOne() {
		if (jujubeCount-- == previousCount) {
			jujubeBoard.MakeOtherGroupsNotInteractable(canvasGroup);
		}

		Assert.IsTrue(jujubeCount >= 0, "Jujube count for this group goes to negative");
	}

	internal void UnpickOne() {
		if (++jujubeCount == previousCount) {
			jujubeBoard.SetAllGroupsInteractable(true);
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