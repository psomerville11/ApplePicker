using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public TextMeshProUGUI scoreGT;

    private bool collidedWithBranch = false;

    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<TextMeshProUGUI>();
        scoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;

    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);

            var score = int.Parse(scoreGT.text);
            score += 100;
            scoreGT.text = score.ToString();

            if (score > HighScore.score)
            {
                HighScore.score = score;
            }

            ApplePicker ap = Camera.main.GetComponent<ApplePicker>();
            ap.PlayAppleCollectSound();
        }
        else if (collidedWith.tag == "Branch")
        {
            // For some reason, the branch was causing multiple OnCollisionEnter events so
            // I added this workaround
            if (collidedWithBranch)
            {
                return;
            }

            // Theres no need to set this back to false because this basket should be deleted soon
            collidedWithBranch = true;
            collidedWith.GetComponent<Collider>().enabled = false;
            Destroy(collidedWith);

            ApplePicker ap = Camera.main.GetComponent<ApplePicker>();
            ap.LifeLost();
        }
    }
}
