using UnityEngine;

public class MainGameController
{
    [SerializeField] private MinigameScriptableObject minigames;
    [SerializeField] private MinigameSlot leftSlot, rightSlot;
    
    public struct MinigameSlot
    {
        [SerializeField] private GameObject iconParent;
        public MinigameScriptableObject data;
        public int playerWon;
    }
    
    public void GameSelection()
    {
        
    }

    public void EnterGame(MinigameSlot slot)
    {
        var game = slot.data;
    }
}