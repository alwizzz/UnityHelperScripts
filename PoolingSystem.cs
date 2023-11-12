using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoolingSystem : StaticReference<PoolingSystem>
{
    [Header("POOLING SYSTEM")]
    [SerializeField] protected int poolAmount;
    [SerializeField] protected GameObject prefab;
    protected List<GameObject> pool = new List<GameObject>();

    protected override void BaseAwake(PoolingSystem tInstance)
    {
        base.BaseAwake(tInstance);
        Populate();
    }

    protected void Populate()
    {
        for (int i = 0; i < poolAmount; i++)
        {
            GameObject poolObject = Instantiate(prefab, transform.position, Quaternion.identity);
            pool.Add(poolObject);
            ResetObject(poolObject);
        }
    }

    protected void ResetObject(GameObject poolObject)
    {
        poolObject.SetActive(false);
        poolObject.transform.position = transform.position;
        poolObject.transform.parent = transform;
    }

    public GameObject Take(Vector3 position)
    {
        GameObject poolObject = pool.Find((item) => !item.activeInHierarchy);
        if (poolObject == null)
        {
            print("All pool object is currently taken!");
        }
        else
        {
            poolObject.transform.position = position;
            poolObject.SetActive(true);
        }

        return poolObject;
    }

    public void Return(GameObject poolObject)
    {
        ResetObject(poolObject);
    }

    private void OnDestroy()
    {
        BaseOnDestroy();
    }
}
