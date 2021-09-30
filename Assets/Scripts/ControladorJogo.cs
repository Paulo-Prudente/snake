using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorJogo : MonoBehaviour
{

    public Cobra cobra;
    private GridFase gridFase;
    /*private GameObject comidaGameObject;
    private Vector2Int comidaPosicaoGrid;
    private int largura=20;
    private int altura=20;*/

    void Start()
    {
        gridFase = new GridFase(20, 20);
        //InvokeRepeating("SpawnComida", 1.0f, 1.0f);

        cobra.Setup(gridFase);
        gridFase.Setup(cobra);
    }
    
    /*
    void SpawnComida()
    {
        comidaPosicaoGrid = new Vector2Int(Random.Range(0, largura), Random.Range(0, altura));

        comidaGameObject = new GameObject("Comida", typeof(SpriteRenderer));
        comidaGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.instace.cabecaCobraSprite;
        comidaGameObject.transform.position = new Vector3(comidaPosicaoGrid.x, comidaPosicaoGrid.y);
    }
    
    void cobraAndou(Vector2Int cobraPosicaoGrid)
    {
        if(cobraPosicaoGrid == comidaPosicaoGrid)
        {
            Object.Destroy(comidaGameObject);
            SpawnComida();
            print("comeste");
        }
    }
    */
}
