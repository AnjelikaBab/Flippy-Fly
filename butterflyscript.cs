using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class butterflyscript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrengh;
    public LogicScript logic;
    public bool butterflyIsAlive = true;
    public AudioSource WooshSFX;
    public AudioSource DeathSFX;


    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)==true && butterflyIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrengh;
            WooshSFX.Play();


        }

        if (transform.position.y < -14.38 || transform.position.y > 11)
        {
            logic.gameOver();
            DeathSFX.Play();


        }



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        butterflyIsAlive = false;
    }
}
