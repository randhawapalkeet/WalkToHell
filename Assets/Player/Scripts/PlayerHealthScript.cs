using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthScript : HealthSystem
{


    public GameObject healthBar;

    public Slider healthSilder;

    public GameObject gameOverCanvas;

    public bool isDead;

    public GameObject gravePrefab;

    // Start is called before the first frame update
    void start()
    {
        healthBar = GameObject.Find("Canvas/HealthBar");
        healthSilder = healthBar.GetComponent<Slider>();
        gameOverCanvas = GameObject.Find("GameOverCanvas");

        gameOverCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        healthSilder.value = health;
        
        DeathCheck();

        
    }


    void DeathCheck()
    {
        Vector3 graveAddOffset = new Vector3(0,-0.5f,0);
        if(health < 1)
        {
            isDead = true;
            gameOverCanvas.SetActive(true);
            Instantiate(gravePrefab, transform.position+graveAddOffset, transform.rotation);
        }
        else
        {
            isDead = false;
        }
        die(isDead);
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "Gate")
        {
           
            health -= gateDamage;
             Debug.Log(health);
        }

        

        if(col.collider.tag == "Enemy")
        {
            health -= enemyDamage;
        }

        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Coins")
		{

			string collidername = col.name;
			Destroy(GameObject.Find(collidername));
            if(health < maxHealth)
			    health += 1;
			//scoret.GetComponent<Text>().text = score.ToString();

            Debug.Log(health);

		}
        
    }

}
