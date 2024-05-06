using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGrid : MonoBehaviour
{
    public GameObject MapTile;
    private int Random_int;
    public int PlayerPin = 0;
    public List<MapTile> Boss;
    public int boolean;

    // Start is called before the first frame update
    void Start()
    {
        MapTile = Resources.Load<GameObject>("Prefabs/MapTile");
        Boss = DataBase.instance.MapTileArray.FindAll(x => x.TileName == "보스");

        MapBuild();
    }

    void TileChoice()
    {
        
    }

    void MapBuild(){

        for(int Map = 0; Map < 999; Map++){
            if(Map > 0 && Map%100 == 0)
            {
                Random_int = Random.Range(0, Boss.Count);
                Debug.Log("Boss : " + Random_int);
                PlayerSettingData.instance.Mapline.Add(Boss[Random_int]);
                continue;
            }

            do
            {
            Random_int = Random.Range(0, DataBase.instance.MapTileArray.Count);
            boolean = 0;

            if(DataBase.instance.MapTileArray[Random_int].TileName == "보스")
                {
                    boolean = 1;
                }
            Debug.Log(Random_int);
            }
            while(boolean == 1);
            PlayerSettingData.instance.Mapline.Add(DataBase.instance.MapTileArray[Random_int]); // Map 가져오기
            // MapTileInfo.Add(Instantiate(MapTile, gameObject.transform));
            // MapTileInfo[Map].GetComponent<MapRandom>().Set_Map = PlayerSettingData.instance.Mapline[Map];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
