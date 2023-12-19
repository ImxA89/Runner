using System;
using UnityEngine;

public interface ISpawnedObject 
{
    public event Action<GameObject> Died;
}
