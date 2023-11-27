using UnityEngine;
//Organize code and prevent naming collisions
namespace Level_2
{
    public class Level2PickUpWeapon : MonoBehaviour
    {
        public Gun gun;
        public Rigidbody rb;
        public BoxCollider coll;
        public Transform player, gunContainer, fpsCam;

        public float pickupRange;
        public float dropForwardForce, dropUpwardForce;

        public bool equipped;
        public static bool slotFull;

        private Vector3 originalScale;

        public Level2KillCounter killCounter;
    
        private void Start()
        {
            //Set up
            if (!equipped)
            {
                gun.enabled = false;
                rb.isKinematic = false;
                coll.isTrigger = false;
            }
            if (equipped)
            {
                gun.enabled = true;
                rb.isKinematic = true;
                coll.isTrigger = true;
                slotFull = true;
            }
        
            originalScale = transform.localScale;
        
        }

        private void Update()
        {
            //Check if the player is in range and if "E" is pressed
            Vector3 distanceToPlayer = player.position - transform.position;
            if (!equipped && distanceToPlayer.magnitude <= pickupRange && Input.GetKeyDown(KeyCode.E) && !slotFull)
            {
                PickUp();
            }
        
            //Drop if equipped and "Q" is pressed
            if (equipped && Input.GetKeyDown(KeyCode.Q))
            {
                Drop();
            }
        
            if (equipped)
            {
                // Position the weapon relative to the camera's position and rotation
                transform.localPosition = new Vector3(0.21f, -2.9f, 0.35f); // Adjust these values
                transform.localRotation = Quaternion.Euler(Vector3.zero); // Optional: You can also adjust rotation if needed
            
            }

            if (equipped && killCounter.bulletCount == 0)
            {
                Drop();
            }
        }

        private void PickUp()
        {
	
            equipped = true;
            slotFull = true;
        
            //Make weapon a child of the camera and move it to default position
            transform.SetParent(gunContainer);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.Euler(Vector3.zero);
            transform.localScale = new Vector3(originalScale.x, originalScale.y + 0.92088f, originalScale.z);
        
            //Make Rigidbody kinematic and BoxCollider a trigger
            rb.isKinematic = true;
            coll.isTrigger = true;
        
            //Enable script
            gun.enabled = true;
        
            killCounter.bulletCount = killCounter.maxBullets;
            killCounter.UpdateBulletCountText();
        }

        private void Drop()
        {
	
            equipped = false;
            slotFull = false;
        
            Vector3 currentScale = transform.localScale;

            //Set parent to null
            transform.SetParent(null);
        
            //Make Rigidbody kinematic and BoxCollider a trigger
            rb.isKinematic = false;
            coll.isTrigger = false;
        
            //Gun carries momentum of player
            rb.velocity = player.GetComponent<Rigidbody>().velocity;
        
            //Add force
            rb.AddForce(fpsCam.forward * dropForwardForce, ForceMode.Impulse);
            rb.AddForce(fpsCam.up * dropUpwardForce, ForceMode.Impulse);
        
            //Disable script
            gun.enabled = false;
        }
    }
}