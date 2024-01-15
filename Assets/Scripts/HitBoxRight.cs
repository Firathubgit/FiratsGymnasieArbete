using UnityEngine;

public class HitBoxRight : MonoBehaviour
{
    // Damage value for the right hitbox
    public int RDamage = 20;

    // Layer mask to filter collisions
    public LayerMask layerMask;

    // Reference to the HurtBoxLeft script
    HurtBoxLeft hurtBoxLeft;

    private void Start()
    {
        // Find and store the HurtBoxLeft script in the scene
        hurtBoxLeft = FindObjectOfType<HurtBoxLeft>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object's layer is included in the specified layer mask
        if (layerMask == (layerMask | (1 << other.transform.gameObject.layer)))
        {
            // If the layer is valid, apply damage to the player on the left side
            hurtBoxLeft.playerHealth1.TakeDamagePlayer1(RDamage);
        }
    }
}
