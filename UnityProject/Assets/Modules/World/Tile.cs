using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Tile : MonoBehaviour
    {
        protected Map m_map;

        public Position Position;

        public float Noise;
        public float Noise2;

        protected List<TileElement> m_elementList = new List<TileElement>();

        public Tile Initialize(Map _map, int _x, int _y)
        {
            m_map = _map;

            gameObject.name = "_tile_" + _x + "_" + _y;

            transform.SetParent(m_map.TileContainer);
            transform.position = new Vector3(_x, 0, _y);

            Noise = GetNoise(_x, _y, 0);
            Noise2 = GetNoise(_x, _y, 20);

            Position = new Position(_x, _y);

            InitializeMaterial();
            InitializeElements();

            return this;
        }

        protected void InitializeMaterial()
        {
            if (Noise >= 0.4f)
            {
                transform.position = new Vector3(Position.x, 0.1f, Position.y);
                GetComponent<MeshRenderer>().material = World.Instance.TileReference.GrassMat;
            }
            else if (Noise < 0.4f)
            {
                transform.position = new Vector3(Position.x, 0, Position.y);
                GetComponent<MeshRenderer>().material = World.Instance.TileReference.WaterMat;
            }
        }

        protected void InitializeElements()
        {
            if (Noise >= 0.5f && Noise2 > 0.7f)
            {
                GameObject tree = GameObject.Instantiate<GameObject>(World.Instance.MapReference.Tree);
                tree.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
                float random = Random.Range(0.5f, 1f);
                tree.transform.localScale = new Vector3(random, random, random);
                tree.transform.SetParent(m_map.MapElementContainer);
                tree.AddComponent<MapElement>().SetTile(this);
            }
        }

        public void AddElement(TileElement _element)
        {
            m_elementList.Add(_element);
        }

        public void RemoveElement(TileElement _element)
        {
            m_elementList.Remove(_element);
        }

        protected float GetNoise(float _x, float _y, float _z)
        {
            return ((float)m_map.Noise.Evaluate(_x * m_map.Factor, _y * m_map.Factor, _z * m_map.Factor)) + 1 * 0.5f;
        }
    }
}