using System;

namespace C1gameProject
{
    public abstract class GameField
    {
        public int index;
        public string name;

        public GameField(int _index, string _name)
        {
            index = _index;
            name = _name;
        }

        public abstract string PlayerAction(Player player);

    }
}
