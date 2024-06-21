
using UnityEngine;


public class WeaponShoot : MonoBehaviour
{
    [SerializeField] private float _projectileSpeed;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _cdTime;
    [SerializeField] private float _flashDissapear;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _muzzleFlash;
    [SerializeField] private Transform _muzzlePosition;
    private Animator _anim;

    public float knockForce;
    public int damage;

    private float _lastShotTime;
    private GameObject _muzzleFlashInstance;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        
    }

    private void Update()
    {
        if (playerInput.rightStick.magnitude > 0.5f && CanShoot()) 
        {
            Shoot();
        }

        if(_muzzleFlashInstance != null)
        {
            _muzzleFlashInstance.transform.position = _firePoint.position;
            _muzzleFlashInstance.transform.rotation = _firePoint.rotation;
        }

        if (playerInput.rightStick.magnitude > 0.5f)
        {
            _anim.enabled = true;
        }
        else
        {
            _anim.enabled = false;
        }
    }
    private void Shoot()
    {
        GameObject bulletShoot = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        bulletShoot.GetComponent<Rigidbody2D>().AddForce(transform.right.normalized * _projectileSpeed, ForceMode2D.Impulse);
        _anim.SetTrigger("Shoot");
        MuzzleFlash();
        _lastShotTime = Time.time;
            
    }

    private void MuzzleFlash()
    {
        _muzzleFlashInstance = Instantiate(_muzzleFlash, _firePoint.position, _firePoint.rotation);
        Destroy(_muzzleFlashInstance, _flashDissapear);
    }

    private bool CanShoot()
    {
        return Time.time - _lastShotTime >= _cdTime;
    }
}