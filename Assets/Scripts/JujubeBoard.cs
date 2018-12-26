using UnityEngine;

public class JujubeBoard : MonoBehaviour {
	private CanvasGroup[] allCanvasGroups = null; // TOTHINK: Any way to encapsulate this var from me?

	internal CanvasGroup[] AllCanvasGroups {
		get {
			if (allCanvasGroups == null) {
				allCanvasGroups = GetComponentsInChildren<CanvasGroup>();
			}
			return allCanvasGroups;
		}
	}

	internal void MakeAllGroupsInteractable() {
		foreach (CanvasGroup canvasGroup in AllCanvasGroups) {
			canvasGroup.interactable = true;
		}
	}

	internal void MakeOtherGroupsNotInteractable(CanvasGroup theRemainingGroup) {
		foreach (CanvasGroup canvasGroup in AllCanvasGroups) {
			if (canvasGroup != theRemainingGroup) {
				canvasGroup.interactable = false;
			}
		}
	}
}