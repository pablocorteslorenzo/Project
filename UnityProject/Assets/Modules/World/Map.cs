using UnityEngine;
using Noise;

namespace Game
{
    public class Map : MonoBehaviour
    {
        public int Seed { get; private set; }

        private SimplexNoise m_noise;
        public SimplexNoise Noise { get { return m_noise; } }

        [Range(0, 1)]
        public float Factor = 0.08f;

        public int SizeX;
        public int SizeY;

        public Tile[,] m_tileMap;

        public Transform TileContainer { get; private set; }
        public Transform MapElementContainer { get; private set; }

        public void Initialize(int _seed)
        {
            Seed = _seed;
            TileContainer = new GameObject("_tileContainer").transform;
            TileContainer.SetParent(transform);
            MapElementContainer = new GameObject("_elementsContainer").transform;
            MapElementContainer.SetParent(transform);
            LoadMap();
        }

        public void LoadMap()
        {
            m_noise = new SimplexNoise(Seed);
            SizeX = Mathf.Abs(Mathf.RoundToInt((float)m_noise.Evaluate(Seed, 0) * 120));
            SizeY = Mathf.Abs(Mathf.RoundToInt((float)m_noise.Evaluate(0, Seed) * 120));

            SizeX = Mathf.Clamp(SizeX, Reference.Map.MIN_SIZE_LIMIT, Reference.Map.MAX_SIZE_LIMIT);
            SizeY = Mathf.Clamp(SizeX, Reference.Map.MIN_SIZE_LIMIT, Reference.Map.MAX_SIZE_LIMIT);

            m_tileMap = new Tile[SizeX, SizeY];

            for (int x = 0; x < SizeX; x++)
            {
                for (int y = 0; y < SizeY; y++)
                {
                    m_tileMap[x, y] = CreateTile(x, y);
                }
            }
        }

        private Tile CreateTile(int _x, int _y)
        {
            GameObject tileObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            return tileObject.AddComponent<Tile>().Initialize(this, _x, _y);
        }

        public Tile GetTile(Position _position)
        {
            return m_tileMap[_position.x, _position.y];
        }

        public Tile GetRandomTile()
        {
            return m_tileMap[Random.Range(0, SizeX), Random.Range(0, SizeY)];
        }

        public void ClearMap()
        {
            for (int x = 0; x < SizeX; x++)
            {
                for (int y = 0; y < SizeY; y++)
                {
                    Destroy(m_tileMap[x, y]);
                }
            }
        }
    }

    public static class MapFactory
    {
        public static Map CreateMap()
        {
            return CreateMap(Random.Range(1, 99999));
        }
        public static Map CreateMap(int _seed)
        {
            GameObject newMap = new GameObject("_map_" + _seed);
            Map map = newMap.AddComponent<Map>();
            map.Initialize(_seed);
            return map;
        }
    }
}