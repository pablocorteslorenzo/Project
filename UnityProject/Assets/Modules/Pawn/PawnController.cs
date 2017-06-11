using UnityEngine;

namespace Game
{
    public class PawnController : MonoBehaviour
    {
        protected Pawn m_pawn;
        public Pawn Pawn { get { return m_pawn; } }

        protected void Awake()
        {
            m_pawn = GetComponent<Pawn>();
        }
    }
}
