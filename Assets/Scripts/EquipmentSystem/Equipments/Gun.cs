using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Equipment
{
    [Header("Gun settings")]
    [SerializeField] float damage;
    [SerializeField] float reloadCD;
    [SerializeField] bool reloading = false;
    [Space]
    [SerializeField] int maxAmmo;
    [SerializeField] int currentAmmo;
    [Space]
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gunBodyTrans;
    [SerializeField] Transform bulletSpawn;
    WaitForSeconds reloadWait;

    void Start()
    {
        reloadWait = new WaitForSeconds(reloadCD);
        currentAmmo = maxAmmo;
    }

    public override void Use()
    {
        if (!usable || currentAmmo <= 0) return;

        GameObject g = Instantiate(bullet, bulletSpawn.position, gunBodyTrans.localRotation);
        g.GetComponent<Bullet>().Fire(gunBodyTrans.right);
        StartCoroutine(CR_RefreshCD());

        currentAmmo = Mathf.Max(currentAmmo - 1, 0);
        if (currentAmmo <= 0) Reload();
    }

    public void Reload()
    {
        if (reloading) return;
        StartCoroutine(CR_Reload());
    }

    IEnumerator CR_Reload()
    {
        reloading = true;
        yield return reloadWait;
        currentAmmo = maxAmmo;
        reloading = false;
    }
}
