using UnityEngine;

namespace Game
{
    public static class PlayerFactory
    {
        public const string PLAYER_PREFAB = "";

        public static PlayerController Create(Tile _tile)
        {
            GameObject playerObject = GameObject.Instantiate<GameObject>(World.Instance.PawnReference.Player);
            playerObject.name = "_player";
            PlayerController controller = playerObject.GetComponent<PlayerController>();
            controller.Initialize(_tile);
            return controller;
        }
    }
}