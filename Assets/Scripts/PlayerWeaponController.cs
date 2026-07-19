using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeaponController : MonoBehaviour
{
    [SerializeField] GameObject laserWeapon;
    bool isFiring;
    ParticleSystem laserParticleSystem;

    private void Start()
    {
        laserParticleSystem = laserWeapon.GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        ProcessFiring();    
    }

    private void ProcessFiring()
    {
        var emissionModule = laserParticleSystem.emission;
        emissionModule.enabled = isFiring;
    }

    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }
}
