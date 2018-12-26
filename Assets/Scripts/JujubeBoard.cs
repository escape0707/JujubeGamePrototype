using System.Collections.Generic;
using UnityEngine;

public class JujubeBoard : MonoBehaviour {
	[SerializeField]
	private GameObject groupPrefab;

	[SerializeField] // Warning: can be changed in Unity Editor
	private int[] maxCountForGroups = { 3, 5, 7 }; // According to game basic rules

	private List<CanvasGroup> allCanvasGroups = new List<CanvasGroup>();
	private List<JujubeGroup> allJujubeGroups = new List<JujubeGroup>();

	internal void MakeAllGroupsInteractable() {
		foreach (CanvasGroup canvasGroup in allCanvasGroups) {
			canvasGroup.interactable = true;
		}
	}

	internal bool CheckGameOver() {
		foreach (var childScript in allJujubeGroups) {
			if (!childScript.IsEmpty) {
				return false;
			}
		}
		return true;
	}

	internal void MakeOtherGroupsNotInteractable(CanvasGroup theRemainingGroup) {
		foreach (CanvasGroup canvasGroup in allCanvasGroups) {
			if (canvasGroup != theRemainingGroup) {
				canvasGroup.interactable = false;
			}
		}
	}

	void Awake() {
		foreach (int max in maxCountForGroups) {
			GameObject child = Instantiate(groupPrefab, transform);
			allCanvasGroups.Add(child.GetComponent<CanvasGroup>());

			JujubeGroup childScript = child.GetComponent<JujubeGroup>();
			allJujubeGroups.Add(childScript);
			childScript.MaxForGroup = max;
		}
	}
}