using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RandomMapTest;

public class LoadStage : MonoBehaviour
{
    public int Seed;
    public int MapSize;
    public int TileRate;
    public int PopRate;


    // Start is called before the first frame update
    void Start()
    {

        //var positions2 = new RandomMap2(_mapSize, _min, _max, _rate).MapBase;
        ////var baseCube = (GameObject)Resources.Load("TestCube");
        ////var texture = Resources.Load("stone01.jpg") as Texture2D;

        var scale = 2;
        //var baseStage = GameObject.CreatePrimitive(PrimitiveType.Cube);

        var map = new RandomMap(MapSize, TileRate, PopRate);

        if (Seed == 0)
            map.CreateMap();
        else
            map.CreateMap(Seed);

        map.IndicateInfo();
        foreach(var pos in map.MapDic)
        {
            if (pos.Value == -1) continue;
            var baseCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            baseCube.GetComponent<Renderer>().material.color = Color.grey;

            if (pos.Value == 0)
            {
                baseCube.transform.localScale = new Vector3(scale, scale / 2, scale);
                baseCube.transform.position = new Vector3(pos.Key.x * scale, 0, pos.Key.z * scale);
            }
            else
            {
                baseCube.transform.localScale = new Vector3(scale, scale, scale);
                baseCube.transform.position = new Vector3(pos.Key.x * scale, scale / 2, pos.Key.z * scale);
            }
            //Instantiate(baseCube, new Vector3(position[0] * 4, pos.Value ? 0 : 3, position[1] * 4), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
