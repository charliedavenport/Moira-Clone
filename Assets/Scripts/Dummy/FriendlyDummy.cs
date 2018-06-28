using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyDummy : MonoBehaviour, ITeammate {

    const float MAX_HP = 100f;
    [SerializeField] private DummyCollision collision;
    [SerializeField] private GameObject model;

    // ITeammate
    public float Health
    {
        get; set;
    }

    // ITeammate
    public void AddHealth(float hp)
    {
        Health = Mathf.Clamp(Health + hp, 0f, MAX_HP);
        if (Health == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        StartCoroutine(doDeath());
    }

	IEnumerator doDeath()
    {
        var cube_RBs = model.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in cube_RBs)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        }

        yield return new WaitForSeconds(1f);

        this.enabled = false;
    }


}
