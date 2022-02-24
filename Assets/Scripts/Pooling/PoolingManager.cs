using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
    public class PooledItems
    {
        public string Name;
        public GameObject objectToPool;
        public int amount;
    }
[System.Serializable]
public class PooledItems2
{
    public string Name;
    public GameObject objectToPool;
    public int amount;
}
public class PoolingManager : MonoBehaviour
{
    public GameObject playerParent;

    private static PoolingManager _instance;
    public static PoolingManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PoolingManager>();
            }
            return _instance;
        }
    }

    [SerializeField]
    private List<PooledItems> pooledLists = new List<PooledItems>();
    [SerializeField]
    private List<PooledItems2> pooledLists2 = new List<PooledItems2>();

    [SerializeField]
    private Dictionary<string, List<GameObject>> _items = new Dictionary<string, List<GameObject>>();

    void Awake()
    {
        for(int i=0; i<pooledLists.Count; i++)
        {
            PooledItems l = pooledLists[i];
            _items.Add(l.Name, new List<GameObject>());

            for(int j = 0; j < l.amount; j++)
            {
                GameObject tmp;

                tmp = Instantiate(l.objectToPool);
                tmp.transform.parent = playerParent.transform;
                tmp.SetActive(false);
                
                _items[l.Name].Add(tmp);
            }
        }
        for (int i = 0; i < pooledLists2.Count; i++)
        {
            PooledItems2 l = pooledLists2[i];
            _items.Add(l.Name, new List<GameObject>());

            for (int j = 0; j < l.amount; j++)
            {
                GameObject tmp;

                tmp = Instantiate(l.objectToPool);
                tmp.SetActive(false);

                _items[l.Name].Add(tmp);
            }
        }
    }

    public GameObject GetPooledObject(string name)
    {
        List<GameObject> tmp = _items[name];
        for (int i = 0; i<tmp.Count; i++)
        {
            if (!tmp[i].activeInHierarchy)
            {
                return tmp[i];
            } 
        }
        return null;
    }

    
}
