using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeaponController : MonoBehaviour
{
    [SerializeField] RectTransform crosshair;
    [SerializeField] GameObject[] laserWeapons;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetPointDistance = 100f;
    bool isFiring;
    ParticleSystem[] laserParticles;

    private void Start()
    {
        Cursor.visible = false;

        laserParticles = new ParticleSystem[laserWeapons.Length];
        for(int i = 0; i < laserWeapons.Length; i++)
        {
            laserParticles[i] = laserWeapons[i].GetComponent<ParticleSystem>();
        }
    }

    private void Update()
    {
        ProcessFiring();    
        MoveCrosshair();
        MoveTargetPoint();
        AimLasers();
    }

    private void AimLasers()
    {
        foreach(GameObject laser in laserWeapons)
        {
            Vector3 fireDirection = targetPoint.position - this.transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            laser.transform.rotation = rotationToTarget;
        }
    }

    private void MoveTargetPoint()
    {
        var mousePosition = Mouse.current.position.ReadValue();
        var targetPosition = new Vector3(mousePosition.x, mousePosition.y, targetPointDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPosition);
    }

    private void MoveCrosshair()
    {
        crosshair.position = Mouse.current.position.ReadValue();
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
