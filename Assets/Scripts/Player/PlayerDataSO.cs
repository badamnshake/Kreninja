using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "Data", menuName = "Player/PlayerData", order = 1)]
    public class PlayerDataSO : ScriptableObject
    {
        public AnimatorOverrideController animatorOverrideController; 
        public string Name;
    }
}