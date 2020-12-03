using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject ObjectToSpawn;
  
    protected void SpawnObject(Transform CustomTransform)
    { 
             Instantiate(ObjectToSpawn, CustomTransform.position, CustomTransform.rotation);  
    }
}
