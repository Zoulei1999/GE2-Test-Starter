using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NematodeSchool : MonoBehaviour
{
    public GameObject prefab;

    [Range (1, 5000)]
    public int radius = 50;
    
    public int count = 10;

    // Start is called before the first frame update
    void Awake()
    {
        // Put your code here
        Vector3 center = transform.position;
        for (int i = 0; i < count; i++)
        {
            Vector3 pos = Circle(center, radius);
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center-pos);
            Instantiate(prefab, pos, rot);       
        }
    }

    Vector3 Circle ( Vector3 center, int radius){
         float ang = Random.value * 360;
         Vector3 pos;
         pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
         pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
         pos.z = center.z;
         return pos;
     }

    // Update is called once per frame
    void Update()
    {
        
    }
}
