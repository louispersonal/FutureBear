using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePoolController : MonoBehaviour
{
    [SerializeField]
    BaseProjectile _baseProjectilePrefab;

    [SerializeField]
    int _initialPoolCount;

    private List<BaseProjectile> _projectilePool = new List<BaseProjectile>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _initialPoolCount; i++)
        {
            BaseProjectile projectile = Instantiate(_baseProjectilePrefab, this.transform);
            _projectilePool.Add(projectile);
            projectile.gameObject.SetActive(false);
        }
    }


    public BaseProjectile GetAvailableProjectile()
    {
        for (int i = 0; i < _projectilePool.Count; i++)
        {
            if (!_projectilePool[i].gameObject.activeInHierarchy)
            {
                return _projectilePool[i];
            }
        }
        BaseProjectile newProjectile = Instantiate(_baseProjectilePrefab, this.transform);
        _projectilePool.Add(newProjectile);
        return newProjectile;
    }
}
