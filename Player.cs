using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace C1gameProject
{
    public class Player
    {
        public static int initialAmountOfMoney = 2000;
        public int currentAmountOfMoney = initialAmountOfMoney;
        public static int allTiles = 20;
        public List<CityField> cityField = new List<CityField>();

        public Sprite sprite;

        public int currentPosition = 0;
        public static int index;

        public Player(int _index)
        {
            index = _index;
        }
        public Player(Sprite _sprite, int _index)
        {
            sprite = _sprite;
            index = _index;
        }

        public void MoreMoney(int amount)
        {
            currentAmountOfMoney += amount;
        }

        public void LessMoney(int amount)
        {
            currentAmountOfMoney -= amount;
        }


        public void SetPosition(int newPosition)
        {
            int modifiedPosition = newPosition;

            if (modifiedPosition < 0)
            {
                modifiedPosition += allTiles;
            }
            if (modifiedPosition >= allTiles)
            {
                modifiedPosition = modifiedPosition - allTiles;
                MoreMoney(200);
            }
            currentPosition = modifiedPosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite.texture, sprite.rectangle, Color.White);
        }
    }
}
