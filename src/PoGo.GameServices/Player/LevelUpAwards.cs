using Google.Protobuf.Collections;
using POGOProtos.Inventory.Item;
using System.Collections.Generic;

namespace PoGo.GameServices.Player
{
    public class LevelUpRewards
    {

        /// <summary>
        /// 
        /// </summary>
        public List<ItemAward> ItemsAwarded { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ItemId> ItemsUnlocked { get; set; }

        public LevelUpRewards(List<ItemAward> itemsAwarded, List<ItemId> itemsUnlocked)
        {
            ItemsAwarded = itemsAwarded;
            ItemsUnlocked = itemsUnlocked;
        }

    }
}
