using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cobra : MonoBehaviour
{
    private Vector2Int gridMovimentoDirecao;
    private Vector2Int gridPosition;
    private float gridMovimentoTimer;
    private float gridMovimentoTimerMax;
    private GridFase gridfase;

    public int tamanhoCobra;
    public List<Vector2Int> listaPosicoesCobra;
    public List<PartedoCorpoCobra> listaPartedoCorpoCobra;

    public void Setup(GridFase gridfase)
    {
        this.gridfase = gridfase;
    }

    private void Awake()
    {
        gridPosition = new Vector2Int(10, 10);
        gridMovimentoTimerMax = 0.25f;
        gridMovimentoTimer = gridMovimentoTimerMax;
        gridMovimentoDirecao = new Vector2Int(1, 0);

        listaPosicoesCobra = new List<Vector2Int>();
        tamanhoCobra = 0;
        listaPartedoCorpoCobra = new List<PartedoCorpoCobra>();

    }

    private void Update()
    {
        Movimento();
        Controle();
    }

    private void Movimento()
    {
        gridMovimentoTimer += Time.deltaTime;
        if (gridMovimentoTimer >= gridMovimentoTimerMax)
        {
            gridMovimentoTimer -= gridMovimentoTimerMax;

            listaPosicoesCobra.Insert(0, gridPosition);

            gridPosition += gridMovimentoDirecao;

            bool cobraComeu = gridfase.TentarComer(gridPosition);
            if (cobraComeu)
            {
                //COBRA COMEU. AUMENTAR CORPO.
                tamanhoCobra++;
                CriarCorpoCobra();
            }

            if (listaPosicoesCobra.Count >= tamanhoCobra+1)
            {
                listaPosicoesCobra.RemoveAt(listaPosicoesCobra.Count - 1);
            }

            foreach(PartedoCorpoCobra partedocorpocobra in listaPartedoCorpoCobra)
            {
                Vector2Int partedoCorpoCobraPosicaoGrid = partedocorpocobra.GetPosicaoGrid();
                if(gridPosition == partedoCorpoCobraPosicaoGrid)
                {
                    //GAMEOVER
                    SceneManager.LoadScene(0);
                }
            }

            transform.position = new Vector3(gridPosition.x, gridPosition.y);

            UpdateCorpoCobra();
            
        }
    }

    private void Controle()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (gridMovimentoDirecao.y != -1)
            {
                gridMovimentoDirecao.x = 0;
                gridMovimentoDirecao.y = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (gridMovimentoDirecao.y != 1)
            {
                gridMovimentoDirecao.x = 0;
                gridMovimentoDirecao.y = -1;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (gridMovimentoDirecao.x != -1)
            {
                gridMovimentoDirecao.x = 1;
                gridMovimentoDirecao.y = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (gridMovimentoDirecao.x != 1)
            {
                gridMovimentoDirecao.x = -1;
                gridMovimentoDirecao.y = 0;
            }
        }
    }

    private void CriarCorpoCobra()
    {
        listaPartedoCorpoCobra.Add(new PartedoCorpoCobra(listaPartedoCorpoCobra.Count));
    }

    private void UpdateCorpoCobra()
    {
        for (int i = 0; i < listaPartedoCorpoCobra.Count; i++)
        {
            listaPartedoCorpoCobra[i].SetPosicaoGrid(listaPosicoesCobra[i]);
        }
    }

    public Vector2Int GetPosicaoGrid()
    {
        return gridPosition;
    }



    //retorna a lista completa de posições ocupadas pela cobra(cabeça e corpo)
    public List<Vector2Int> GetTodasPosicaoGridCobraLista()
    {
        List<Vector2Int> listaPosicaoGrid = new List<Vector2Int>() { gridPosition };
        listaPosicaoGrid.AddRange(listaPosicoesCobra);
        return listaPosicaoGrid;
    }

    public class PartedoCorpoCobra
    {
        private Vector2Int gridPosition;
        private Transform transform;
        //private GridFase gridfase;

        public PartedoCorpoCobra(int corpoIndex)
        {
            GameObject corpoCobraGameObject = new GameObject("CorpoCobra", typeof(SpriteRenderer));
            //corpoCobraGameObject = gridfase.GetComida();

            corpoCobraGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.instace.corpoCobraSprite;
            transform = corpoCobraGameObject.transform;
        }

        public void SetPosicaoGrid(Vector2Int gridPosition)
        {
            this.gridPosition = gridPosition;
            transform.position = new Vector3(gridPosition.x, gridPosition.y);
        }

        public Vector2Int GetPosicaoGrid()
        {
            return gridPosition;
        }
    }
}
