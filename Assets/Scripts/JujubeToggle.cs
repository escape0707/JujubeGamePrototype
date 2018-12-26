using UnityEngine;
using UnityEngine.UI;

public class JujubeToggle : MonoBehaviour {
	internal static bool isInternalToggle = false; // TODO: What a piece of ...
	private Toggle toggle;
	private JujubeGroup group;

	internal bool isOn {
		get {
			return toggle.isOn;
		}
		set {
			isInternalToggle = value != toggle.isOn;
			toggle.isOn = value;
		}
	}

	void Awake() {
		group = GetComponentInParent<JujubeGroup>(); // Interesting.. I shouldn't get notified but ask for everything I should know by myself instead?

		toggle = GetComponent<Toggle>();
		toggle.onValueChanged.AddListener(delegate {
			ToggleValueChanged(toggle);
		});
	}

	void ToggleValueChanged(Toggle changedToggle) {
		if (isInternalToggle) {
			isInternalToggle = false;
			return;
		}

		if (changedToggle.isOn) {
			group.UnpickOne();
		} else {
			group.PickOne();
		}
	}
}