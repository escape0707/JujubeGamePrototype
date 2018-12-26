using System;
using UnityEngine;
using UnityEngine.UI;

public class JujubeToggle : MonoBehaviour {
	private Toggle jujubeToggle;
	private JujubeGroup groupController;

	void Awake() {
		jujubeToggle = GetComponent<Toggle>();
		jujubeToggle.onValueChanged.AddListener(delegate {
			ToggleValueChanged(jujubeToggle);
		});

		groupController = GetComponentInParent<JujubeGroup>();
	}

	void ToggleValueChanged(Toggle changedToggle) {
		if (changedToggle.isOn) {
			groupController.ReturnOne();
			if (groupController.NotPickedInThisTurn()){
				groupController.MakeAllGroupsInteractable();
			}
		} else {
			groupController.PickOne();
			MakeOtherGroupsNotInteractable();
		}
	}

  private void MakeOtherGroupsNotInteractable()
  {
    throw new NotImplementedException();
  }
}