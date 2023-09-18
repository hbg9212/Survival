using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour
{
    public int damage;
    public float damageRate;

    private List<IDamageale> thingsToDamage = new List<IDamageale>();

    private void Start()
    {
        InvokeRepeating("DealDamage", 0, damageRate);
    }

    void DealDamage()
    {
        for(int i = 0; i < thingsToDamage.Count; i++)
        {
            thingsToDamage[i].TakePhysicalDamage(damage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out IDamageale damageale))
        {
            thingsToDamage.Add(damageale);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamageale damageale))
        {
            thingsToDamage.Remove(damageale);
        }
    }
}
