using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGunController : MonoBehaviour
{
    // Configurable variables
    public Sprite bulletSprite;    
    
    private bool canShoot = true; 

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        PointGunToMouse();
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && canShoot && PlayerManager.canShoot())
        {
            canShoot = false;
            var muzzle = this.transform.GetChild(1);
            var proj = this.create();
            proj.transform.position = muzzle.position;
            proj.transform.rotation = muzzle.rotation;
            Vector3 directionVector = muzzle.transform.position - this.transform.GetChild(0).transform.position;
            proj.GetComponent<Rigidbody2D>().AddForce(directionVector * 100, ForceMode2D.Impulse);
            StartCoroutine(ShootDelay());
        }
    }
    

    public GameObject create() 
    {
        var obj = new GameObject("bullet");
        obj.AddComponent<SpriteRenderer>().sprite = this.bulletSprite;
        obj.AddComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        obj.AddComponent<BoxCollider2D>();
        return obj;
    }
    

    IEnumerator ShootDelay()
   {
     yield return new WaitForSeconds(0.5f);
     canShoot = true;
   }

    void PointGunToMouse()
    {
        // Rotate the gun to face the mouse
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);
    }
}
