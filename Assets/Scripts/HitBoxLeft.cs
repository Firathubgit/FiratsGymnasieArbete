using UnityEngine;

public class HitBoxLeft : MonoBehaviour
{
    // Damage value for the left hitbox
    public int LDamage = 20;

    // Layer mask to filter collisions
    public LayerMask layerMask;

    // Reference to the HurtBoxRight script
    HurtBoxRight hurtBoxRight;

    private void Start()
    {
        // Find and store the HurtBoxRight script in the scene
        hurtBoxRight = FindObjectOfType<HurtBoxRight>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object's layer is included in the specified layer mask
        if (layerMask == (layerMask | (1 << other.transform.gameObject.layer)))
        {
            // If the layer is valid, apply damage to the player on the right side
            hurtBoxRight.playerHealth2.TakeDamagePlayer2(LDamage);
        }
    }
}
