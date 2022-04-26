using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nematode : MonoBehaviour{
    
    public int length;

    public Material material;

    private Vector3 segmentSize;

    void Awake(){
        // Put your code here!
        length = Random.Range(3, 30);
        segmentSize = new Vector3(0.1f, 0.1f, 0f);

        for (var i = 0; i < length; i++){//loop for the printing of segments
            
            GameObject segments = GameObject.CreatePrimitive(PrimitiveType.Sphere); //prints spheres

            segments.transform.parent = this.transform;
            segments.transform.position = transform.position - (transform.forward * i);//setting position
            segments.transform.rotation = transform.rotation;//setting rotation
            segments.transform.localScale -= segmentSize;

            segments.GetComponent<Renderer>().material = material;//rendering nematode material
            segments.GetComponent<Renderer>().material.color = Color.HSVToRGB(i / (float)length, 1, 1);//setting colors

            if (i > length/2){//checks if the segment is greater than halfway to either increase or decrease size of the segments
                
                segmentSize -= new Vector3(-0.1f, -0.1f, -0);   
            
            } else {
            
                segmentSize -= new Vector3(0.1f, 0.1f, 0);   
            
            }
        }

        GameObject parent = this.transform.GetChild(0).gameObject; // setting parent object
        parent.AddComponent<Boid>();//adding boid behaviour
        parent.AddComponent<NoiseWander>();//adding noise wander behaviour
        parent.AddComponent<ObstacleAvoidance>();//obstacle avoidance behaviour
    
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}