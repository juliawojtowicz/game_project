using System.Collections.Generic;

namespace C1gameProject
{
    public static class MonopolyBoard
    {
        public static List<Player> players;
        public static List<GameField> allTiles;
        public static int CurrentPlayerIndex;

        public static void InitializeBoard()
        {
            CurrentPlayerIndex = 0;
            players = new List<Player>()
            {
                new Player(1),
                new Player(2)
            };
            allTiles = new List<GameField>()
            {
                new OtherField(0, "START"),
                new CityField(1, "Gdynia", CityField.Countries.Poland, 80, 10),
                new TaxField(2, "Income Tax", 200),
                new CityField(3, "Warsaw", CityField.Countries.Poland, 80, 10),
                new CityField(4, "Cracow", CityField.Countries.Poland, 100, 15),
                new OtherField(5, "Jail"),
                new CityField(6, "Barcelona", CityField.Countries.Spain, 200, 40),
                new CityField(7, "Seville", CityField.Countries.Spain, 200, 40),
                new CityField(8, "Monopoly Space", CityField.Countries.Vehicle, 300, 80),
                new CityField(9, "Madrid", CityField.Countries.Spain, 220, 50),
                new OtherField(10, "Free Parking"),
                new CityField(11, "Stavanger", CityField.Countries.Norway, 280, 70),
                new CityField(12, "Trondheim", CityField.Countries.Norway, 280, 70),
                new CityField(13, "Monopoly Cruise", CityField.Countries.Vehicle, 300, 80),
                new CityField(14, "Oslo", CityField.Countries.Norway, 300, 80),
                new OtherField(15, "Go To Jail"),
                new CityField(16, "Portofino", CityField.Countries.Italy, 400, 120),
                new CityField(17, "Venice", CityField.Countries.Italy, 400, 120),
                new TaxField(18, "Super Tax", 400),
                new CityField(19, "Rome", CityField.Countries.Italy, 420, 140),
            };
        }

        public static void AddCityToPlayer(int fieldIndex, int playerIndex)
        {
            CityField currentField = (CityField)allTiles[fieldIndex];
            currentField.owner = players[playerIndex];

            players[playerIndex].cityField.Add(currentField);

            players[playerIndex].LessMoney(currentField.price);
        }
    }
}
