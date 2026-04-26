using UnityEngine;

public class Gun : MonoBehaviour
{
    public float speed = 60f;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public Camera cam;

    void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

    }

    void Shoot()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        Vector3 targetPoint;

        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(100f);
        }
        Vector3 direction = (targetPoint - firePoint.position).normalized;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(direction));

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = direction * speed;
    }

}