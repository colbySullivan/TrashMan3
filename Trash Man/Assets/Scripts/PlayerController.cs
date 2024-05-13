using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed;

    Rigidbody rb;

    float xInput;
    float yInput;

    int score = 0;
    public int winScore;

    public GameObject winText;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5f)
        {
            SceneManager.LoadScene("Game");
        }
    }

    private void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        rb.AddForce(xInput * speed, 0, yInput * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            other.gameObject.SetActive(false);

            score++;

            if(score >= winScore)
            {
                //win condition met
                winText.SetActive(true);
            }
        }



    }

}
