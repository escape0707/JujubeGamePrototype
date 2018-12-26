using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllJujubeGroups : MonoBehaviour {
	internal static CanvasGroup[] allToggleCanvasGroups = null;

	void Awake() {
		if (allToggleCanvasGroups == null) {
			allToggleCanvasGroups = GetComponentsInChildren<CanvasGroup>();
		}
	}
}