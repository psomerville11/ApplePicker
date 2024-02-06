using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    //Prefab for instantiating apples

    public GameObject applePrefab;
    // Prefab for creating branches
    public GameObject branchPrefab;

    //speed at which apple moves 
    public float speed = 1f;

    //distance at which AppleTree turns around
    public float leftAndRightEdge = 10f;


    //Chance that the AppleTree will change directions
    public float chanceToChangeDirections = 0.1f;

    // Chance that the AppleTree will drop a branch
    public float chanceToDropBranch = 0.1f;

    //Rate at which Apples will be instantiated 
    public float secondBetweenAppleDrops = 1f;


    // Start is called before the first frame update
    void Start()
    {
        //Dropping Apples
        Invoke("Drop", 2f);
    }

    void Drop()
    {
        if (Random.value < chanceToDropBranch)
        {
            GameObject branch = Instantiate(branchPrefab);
            branch.transform.position = transform.position;
        }
        else
        {
            GameObject apple = Instantiate<GameObject>(applePrefab);
            apple.transform.position = transform.position;
        }

        // Infinite Loop with a 1 second pause
        Invoke("Drop", secondBetweenAppleDrops);
    }

    // Update is called once per frame
    void Update()
    {

        //Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //Changing Directions    
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
    }

    void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1; //changing direction
        }
    }



}


