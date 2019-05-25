using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int bulletDamage;
    [SerializeField] private float bulletRange;
    [SerializeField] private KeyCode shootKey;
    public ParticleSystem muzzleFlash; // Fungerar men är förlat och irreterad för att göra om Muzzleflash IGEN.

    [SerializeField] public Camera PlayerCamera;
    private float fireRate = 3f;
    private float fireCooldown;
    // public int HP;
    // public bool isDead = false;

    void Start()
    {

    }
    
    // Update is called once per frame
    private void Update()
    {
       if (Input.GetKey(shootKey))
          {
            if (fireCooldown <= 0)
            {
              shoot();
              fireCooldown = 2;
            }
          }
        fireCooldown -= Time.deltaTime * fireRate;
    }
    private void shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit, bulletRange))
        {
            Debug.Log(hit.transform.name);
            Enemy target = hit.transform.GetComponent<Enemy>();
            if (target != null)
            {
                target.Hit(bulletDamage);
            }
        }
    }
}