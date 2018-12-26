using System.Collections.Generic;
using UnityEngine;

public class JujubeBoard : MonoBehaviour {
	[SerializeField]
	private GameObject groupPrefab;

	private int[] maxCountForGroups = { 3, 5, 7 }; // According to game basic rules

	private List<CanvasGroup> allCanvasGroups = new List<CanvasGroup>();

	internal void MakeAllGroupsInteractable() {
		foreach (CanvasGroup canvasGroup in allCanvasGroups) {
			canvasGroup.interactable = true;
		}
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
			child.GetComponent<JujubeGroup>().MaxForGroup = max;
		}
	}
}