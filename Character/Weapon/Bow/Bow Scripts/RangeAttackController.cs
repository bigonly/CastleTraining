using UnityEngine;

public class RangeAttackController : MonoBehaviour
{
    public GameObject ArrowPrefab;
    public Transform RangeWeaponPosition;
    public Transform ArrowSpawnPoint;
    public Transform TargetPoint;
    public float TimeBetweenShot;

    private Arrow _currentArrow;
    private Vector3 _direction;
    private float _rotationZ;
    private float _timer;
    private bool _hasArrow;

    private void Start()
    {
        CreateArrow();
    }

    private void Update()
    {
        Aim();
        CreateArrow();
        Shoot();
    }

    public void Shoot()
    {
        if (Input.GetButton("Fire1") && _hasArrow)
        {
            _currentArrow.Shot();
            _currentArrow.transform.parent = null;
            _hasArrow = false;
        }
    }

    private void Aim()
    {
        if (Input.GetButton("Fire2")) 
        { 
            _direction = TargetPoint.position - RangeWeaponPosition.position;
            _rotationZ = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
            RangeWeaponPosition.rotation = Quaternion.Euler(0, 0, _rotationZ);
        }
    }

    private void CreateArrow()
    {
        if(!_hasArrow && _timer <= 0)
        {
            _currentArrow = Instantiate(ArrowPrefab, ArrowSpawnPoint).GetComponent<Arrow>();
            _hasArrow = true;
            _timer = TimeBetweenShot;
        }
        else
        {
            _timer -= Time.deltaTime;
        }
    }
}
