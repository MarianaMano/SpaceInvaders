using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{
    [SerializeField]
    GameObject fire = null;

    [SerializeField]
    float cadencia = 1.5f;

    [SerializeField]
    float intervaloCadencia = 1f;

    [SerializeField]
    int vidaIndestrutiveis = 10;

    float tempoQuePassou = 0f;
    float tempoDeDisparo = 0f;

    private void Start()
    {
        NovoTempoDisparo();
    }

    void NovoTempoDisparo()
    {
        tempoDeDisparo = Random.Range(cadencia - intervaloCadencia, cadencia + intervaloCadencia);
    }

    void Update()
    {
        if(tag == "Destrutivel")
        {
            tempoQuePassou += Time.deltaTime;
            if (tempoQuePassou >= tempoDeDisparo)
            {
                Instantiate(fire, transform.position, transform.rotation);
                tempoQuePassou = 0f;
                NovoTempoDisparo();
            }
        }

       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Destrutivel")
        {
            if (collision.gameObject.tag == "DisparoDaNave")
            {
                Destroy(gameObject); // destruir-me
                Destroy(collision.gameObject); // destruir objeto que colidiu
            }
        }
        else
        {
            vidaIndestrutiveis--;
            if(vidaIndestrutiveis == 0)
            {
                Destroy(gameObject);
            }
            Destroy(collision.gameObject);
        }
        
        
    }
}
