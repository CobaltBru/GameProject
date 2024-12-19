using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private GameObject tilePrefab;
    [SerializeField]
    private Transform currentTile;

    [SerializeField]
    private int spawnTileCountAtStart = 100;

    private void Awake()
    {
        for(int i = 0;i< spawnTileCountAtStart;i++)
        {
            CreateTile();
        }
    }

    private void CreateTile()
    {
        GameObject clone = Instantiate(tilePrefab);
        clone.transform.SetParent(transform);
        SpawnTile(clone.transform);
        clone.GetComponent<Tile>().Setup(this);
        clone.transform.GetChild(1).GetComponent<Item>().Setup(gameController);
    }

    public void SpawnTile(Transform tile)
    {
        tile.gameObject.SetActive(true);

        int index = Random.Range(0, 2);
        Vector3 addPosition = index == 0 ? Vector3.right : Vector3.forward;
        tile.position = currentTile.position + addPosition;

        currentTile = tile;

        int spawnItem = Random.Range(0, 100);
        if(spawnItem<20)
        {
            tile.GetChild(1).gameObject.SetActive(true);
        }
    }
}
