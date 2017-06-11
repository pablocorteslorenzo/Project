using UnityEngine;

namespace Game
{
    public class TileElement : MonoBehaviour
    {
        public Tile Tile;
        public Position Position;

        public void SetTile(Tile _tile)
        {
            Tile = _tile;
            Position = Tile.Position;
            transform.position = Tile.transform.position + new Vector3(0, 0.5f, 0);
            Tile.AddElement(this);
        }

        public void SetPosition(Position _position)
        {
            Position = _position;
            Tile = World.Instance.Map.GetTile(Position);
            transform.position = Tile.transform.position + new Vector3(0, 0.5f, 0);
            Tile.AddElement(this);
        }

        public void ChangeTile(Tile _tile)
        {
            Tile.RemoveElement(this);
            SetTile(_tile);
        }
    }
}