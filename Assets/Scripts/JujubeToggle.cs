using UnityEngine;
using UnityEngine.UI;

public class JujubeToggle : MonoBehaviour {
	private Toggle toggle;
	private JujubeGroup group;

	void Awake() {
		group = GetComponentInParent<JujubeGroup>();
		
		toggle = GetComponent<Toggle>();
		toggle.onValueChanged.AddListener(delegate {
			ToggleValueChanged(toggle);
		});
	}

	void ToggleValueChanged(Toggle changedToggle) {
		if (changedToggle.isOn) {
			group.UnpickOne();
		} else {
			group.PickOne();
		}
	}
}