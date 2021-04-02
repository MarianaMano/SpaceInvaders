using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInvaders : MonoBehaviour
{

    [SerializeField]
    GameObject[] invasores; //array; variável indexada; lista de coisas// 

    [SerializeField]
    float nInvasores = 7;

    [SerializeField]
    float xMin = -3f;

    [SerializeField]
    float yMin = -0.5f;

    [SerializeField]
    float xInc = 1f;

    [SerializeField]
    float yInc = 0.5f;


    void Awake()
    {

        /*
         * "pega" num invader, e coloca "nesta" posição
         * repete
         */

        // i = i + 1 ; i += 1 ; i++ //
        
        float y = yMin;

        for (int line = 0; line < invasores.Length; line++)
        {
            
            float x = xMin;
            for (int i = 1; i <= nInvasores; i++)
            {
                GameObject newInvader = Instantiate(invasores[line], transform);
                newInvader.transform.position = new Vector3(x, y, 0f);
                x += xInc;
            }
            y += yInc;

        }


    }

}
