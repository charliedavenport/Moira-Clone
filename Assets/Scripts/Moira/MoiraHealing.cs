using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoiraHealing : MonoBehaviour, IAbility {

    [SerializeField] private Collider m_collider;

    public List<GameObject> Targets { get; private set; }
    public bool isHealing { get; private set; }

    public new Collider collider {
        get
        {
            return m_collider;
        }
        private set
        {
            this.m_collider = value;
        }
    }

    

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Friendly"))
        {

        }
    }

    IEnumerator doHealing(float tick_interval)
    {
        while (true)
        {
            foreach (GameObject _target in Targets)
            {
                try
                {
                    GetComponent<FriendlyDummy>().AddHealth(10f);
                }
                catch (MissingComponentException e)
                {
                    Debug.Log("MoiraHealing.cs: " + e.Message);
                }
                catch (Exception e)
                {
                    Debug.Log("MoiraHealing.cs: " + e.Message);
                }
            }
            yield return new WaitForSeconds(tick_interval);
        }
    }


}
