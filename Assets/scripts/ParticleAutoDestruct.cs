using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAutoDestruct : MonoBehaviour {
    ParticleSystem self;

    private void Start()
    {
        self = GetComponent<ParticleSystem>();
    }
    private void Update()
    {
        if(!self.IsAlive())
        {
            Destroy(gameObject);
        }
    }
}
