using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    private List<GameObject> basketList;
    // Start is called before the first frame update

    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Collider basketCollider = tBasketGO.GetComponent<Collider>();

            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;

            // Disable Colliders
            basketCollider.enabled = false;

            basketList.Add(tBasketGO);
        }

        EnableTopBasketCollision();

    }

    private void EnableTopBasketCollision()
    {
        basketList[basketList.Count - 1].GetComponent<Collider>().enabled = true;
    }

    // Called when an Apple goes off screen or when a Branch is collected
    public void LifeLost()
    {
        // Remove all apples currently spawned
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }

        // Lower basket count by 1
        int basketIndex = basketList.Count - 1;
        GameObject tBasketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);

        EnableTopBasketCollision();

        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("_Scene_0");
        }
    }
}
