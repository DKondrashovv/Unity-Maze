﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget: MonoBehaviour
{
    public void ReactToHit()
    {
        WanderingAI behavior = GetComponent<WanderingAI>();
        if (behavior != null)
        {
            behavior.SetAlive(false);
        }
        StartCoroutine(Die());
    }
    private IEnumerator Die()
    {
        this.transform.Rotate(-35, 0, 0);
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}
