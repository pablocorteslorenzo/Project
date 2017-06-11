using UnityEngine;

namespace Game
{
    public class PlayerController : MonoBehaviour
    {
        private Pawn m_pawn;
        public Pawn Pawn { get { return m_pawn; } }

        public void Initialize(Tile _tile)
        {
            m_pawn = GetComponent<Pawn>();
            m_pawn.SetTile(_tile);
        }
    }
}