using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{
    [SerializeField]
    GameObject fire;

    [SerializeField]
    Transform nozzle;

    [SerializeField]
    float velocidade = 5f;

    [SerializeField]
    int vidas = 3;

    [SerializeField]
    Vector3 initialPosition; 

    float minX, maxX;
    
    // Start is called before the first frame update
    void Start()
    {
        // 0.5 é a metade do tamanho da nave 
        minX = Camera.main.ViewportToWorldPoint(Vector2.zero).x + 0.5f;
        maxX = Camera.main.ViewportToWorldPoint(Vector2.one).x - 0.5f;

        /*
        Debug.Log(bottomLeftWorld); 
        Debug.Log(topRightWorld);
        para verificar as medidas no jogo
        */


    }

    // Update is called once per frame
    void Update()
    {
        /*
        * Se o jogador premir o espaço
        * então criar um disparo
        */

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(fire, nozzle.position, nozzle.rotation);
            // "rotation" p libertar o "fire"
        }

        MoveShip();

    }

    void MoveShip()
    {
        float hMov = Input.GetAxis("Horizontal");
        transform.position += hMov * velocidade * Vector3.right * Time.deltaTime;

        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, minX, maxX);
        transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        vidas--; //vidas -= 1
        if (vidas == 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            transform.position = initialPosition;
        }
        Destroy(collision.gameObject);
    }
}
