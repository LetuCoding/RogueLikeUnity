using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardManager : MonoBehaviour
{
    public class CellData
    {
        public bool passable;
    }
    
    private CellData[,] m_boardData;
    
    
    
    
    
    private Tilemap m_Tilemap;

    public int Width;
    public int Height;
    public Tile[] GroundTiles;
    public Tile[] WallTiles;

    // Start is called before the first frame update
    void Start()
    {
        m_Tilemap = GetComponentInChildren<Tilemap>(); //Llama al tilemap que tiene el BoardManager
        m_boardData = new CellData[Width, Height];
        
        for (int y = 0; y < Height; ++y) 
        {
            for(int x = 0; x < Width; ++x)
            {
                Tile tile;
                m_boardData[x, y] = new CellData();
                
                
                if(x == 0 || y == 0 || x == Width - 1 || y == Height - 1)
                {
                    tile = WallTiles[Random.Range(0, WallTiles.Length)];
                    m_boardData[x, y].passable = false;
                }
                else
                {
                    tile = GroundTiles[Random.Range(0, GroundTiles.Length)];
                    m_boardData[x, y].passable = true;
                }
              
                m_Tilemap.SetTile(new Vector3Int(x, y, 0), tile);
            }
        }
    }

}