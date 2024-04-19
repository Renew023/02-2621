using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGrid : MonoBehaviour
{

    public GameObject MapTile;
    public List<GameObject> MapTileInfo;
    private int Random_int;
    public int PlayerPin = 0;

    // Start is called before the first frame update
    void Start()
    {
        MapTile = Resources.Load<GameObject>("Prefabs/MapTile");
        MapBuild();
        
    }

    void TileChoice()
    {
        
    }

    void MapBuild(){

        for(int Map = 0; Map < 12; Map++){
            Random_int = Random.Range(0, DataBase.instance.MapTileArray.Count);
            Debug.Log(Random_int);
            PlayerSettingData.instance.Mapline.Add(DataBase.instance.MapTileArray[Random_int]); // Map 가져오기
            MapTileInfo.Add(Instantiate(MapTile, gameObject.transform));
            MapTileInfo[Map].GetComponent<MapRandom>().Set_Map = PlayerSettingData.instance.Mapline[Map];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
