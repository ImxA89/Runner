using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] private Transform _contaner;

    public GameObject Instantiat(GameObject prefabs)
    {
        return  Instantiate(prefabs, _contaner);
    }
}
