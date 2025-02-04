using System;

namespace HikanyanLaboratory.Player
{
    [Serializable]
    public class CharacterStatus
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string SpritePath { get; set; } // AddressableのSpriteを使う
        public int Hp { get; set; }
        public int MaxHp { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Spd { get; set; }
        public bool IsAlive => Hp > 0;
    }
}