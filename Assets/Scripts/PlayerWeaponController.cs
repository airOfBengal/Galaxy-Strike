using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeaponController : MonoBehaviour
{
    [SerializeField] GameObject[] laserWeapons;
    bool isFiring;
    ParticleSystem[] laserParticles;

    private void Start()
    {
        laserParticles = new ParticleSystem[laserWeapons.Length];
        for(int i = 0; i < laserWeapons.Length; i++)
        {
            laserParticles[i] = laserWeapons[i].GetComponent<ParticleSystem>();
        }
    }

    private void Update()
    {
        ProcessFiring();    
    }

    private void ProcessFiring()
    {
        foreach(var laser in laserParticles)
        {
            var emissionModule = laser.emission;
            emissionModule.enabled = isFiring;            
        }
    }

    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }
}
