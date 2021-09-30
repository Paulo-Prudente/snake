using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets instace;

    private void Awake()
    {
        instace = this;
    }

    public Sprite cabecaCobraSprite;
    public Sprite corpoCobraSprite;
    public Sprite comidaSprite;
}
