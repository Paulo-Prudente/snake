using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridFase
{
    private Vector2Int comidaPosicaoGrid;
    private int largura;
    private int altura;
    public GameObject comidaGameObject;
    private Cobra cobra;

    public GridFase(int largura, int altura)
    {
        this.largura = largura;
        this.altura = altura;
    }

    public void Setup(Cobra cobra)
    {
        this.cobra = cobra;

        SpawnComida();
    }

    void SpawnComida()
    {
        int corAleat;

        do
        {
            comidaPosicaoGrid = new Vector2Int(Random.Range(0, largura), Random.Range(0, altura));

        } while (cobra.GetTodasPosicaoGridCobraLista().IndexOf(comidaPosicaoGrid)!=-1);

        comidaGameObject = new GameObject("Comida", typeof(SpriteRenderer));
        comidaGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.instace.cabecaCobraSprite;
        comidaGameObject.transform.position = new Vector3(comidaPosicaoGrid.x, comidaPosicaoGrid.y);

        corAleat = Random.Range(1, 4);
        if (corAleat == 1)
            comidaGameObject.GetComponent<Renderer>().material.color = Color.red;
        if (corAleat == 2)
            comidaGameObject.GetComponent<Renderer>().material.color = Color.yellow;
        if (corAleat == 3)
            comidaGameObject.GetComponent<Renderer>().material.color = Color.blue;
    }

    public GameObject GetComida()
    {
        return comidaGameObject;
    }

    public bool TentarComer(Vector2Int cobraPosicaoGrid)
    {
        if (cobraPosicaoGrid == comidaPosicaoGrid)
        {
            Object.Destroy(comidaGameObject);
            SpawnComida();
            return true;
        }
        else
            return false;
    }

}
