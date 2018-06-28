using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyCollision : MonoBehaviour {

	public List<Collider> Colliders { get; private set; }

    private void Awake()
    {
        Colliders = new List<Collider>(GetComponentsInChildren<Collider>());
    }


}
