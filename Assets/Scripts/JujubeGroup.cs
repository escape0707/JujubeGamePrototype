using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class JujubeGroup : MonoBehaviour {
	[SerializeField]
	private GameObject JujubePrefab;

	[SerializeField]
	private int maxJujubeCountForGroup;
	private int jujubeCount;
	private int previousCount; // TODO!! Not maintained.

	internal void PickOne() {
		Assert.IsTrue(--jujubeCount >= 0, "Jujube count for this group goes to negative");
	}

	internal void ReturnOne() {
		Assert.IsTrue(++jujubeCount <= maxJujubeCountForGroup, "Jujube count for this group exceeded its max");
	}

  internal bool NotPickedInThisTurn() {
		return jujubeCount == previousCount;
	}

	void Awake() {
		for (jujubeCount = 0; jujubeCount < maxJujubeCountForGroup; ++jujubeCount) {
			Instantiate(JujubePrefab, transform);
		}
		previousCount = jujubeCount;
	}
}