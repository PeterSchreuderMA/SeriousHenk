using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public float weaponDamage = 10f;
    public float weaponRange = 100f;
    public float weaponImactForce = 30f;

    public float weaponFireRate = 15f;
    public float weaponFireTime = 0f;

    public Camera weaponOwnerCamera;

    public GameObject weaponEffectImpact;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= weaponFireTime)
        {
            weaponFireTime = Time.time + (1f / weaponFireRate);
            Shoot();
        }
    }

    void Shoot()
    {
        Transform _camTrans = weaponOwnerCamera.transform;

        RaycastHit _hit;

        if (Physics.Raycast(_camTrans.position, _camTrans.forward, out _hit, weaponRange))
        {
            print(_hit.transform.name);

            Target _target = _hit.transform.GetComponent<Target>();

            if (_target != null)
            {
                _target.TakeDamage(weaponDamage);
            }

            if (_hit.rigidbody != null)
            {
                _hit.rigidbody.AddForce(-_hit.normal * weaponImactForce);
            }

            if (weaponEffectImpact == null)
                return;

            GameObject weaponEffectImpactGO = Instantiate(weaponEffectImpact, _hit.point, Quaternion.LookRotation(_hit.normal));
            Destroy(weaponEffectImpactGO, 2f);
        }
    }
}
