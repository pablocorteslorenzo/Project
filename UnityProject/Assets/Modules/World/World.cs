using UnityEngine;

namespace Game
{
    public class World : MonoBehaviour
    {
        private static World m_instance;
        public static World Instance { get { return m_instance; } }

        public static bool isSet { get { return m_instance != null; } }

        public int Seed;
        public Map Map { get; private set; }
        public PlayerController Player { get; private set; }

        public TileReference TileReference;
        public MapElementReference MapReference;
        public PawnReference PawnReference;

        private void Awake()
        {
            m_instance = this;
            CreateMap();
            CreatePlayer();
        }

        [ContextMenu("Create Map")]
        public void CreateMap()
        {
            if (Map == null)
            {
                Map = MapFactory.CreateMap(Seed);
            }
            else
            {
                if (Map.Seed != Seed)
                {
                    Map.ClearMap();
                    Destroy(Map.gameObject);
                    Map = MapFactory.CreateMap(Seed);
                }
                else
                {
                    Map.ClearMap();
                    Map.LoadMap();
                }
            }
        }

        public void CreatePlayer()
        {
            if (Player == null)
            {
                Player = PlayerFactory.Create(Map.GetRandomTile());
            }
            else
            {
                Player.Pawn.SetTile(Map.GetRandomTile());
            }
        }
    }
}