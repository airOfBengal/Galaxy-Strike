using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]   GameObject destroyedVfx;

    private void OnParticleCollision(GameObject other) {
        Instantiate(destroyedVfx, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
