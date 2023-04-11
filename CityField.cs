namespace C1gameProject
{
    public class CityField : GameField
    {
        public enum Countries { Poland, Spain, Norway, Italy, Vehicle }
        public Countries country;
        public Player owner;
        public int price;
        public int rental;
        public CityField(int _index, string _name, Countries _country, int _price, int _rental) : base(_index, _name)
        {
            country = _country;
            price = _price;
            rental = _rental;
            owner = null;
        }

        public override string PlayerAction(Player player)
        {
            if (owner == null)
            {
                return $"You can buy \n{name} field.";
            }
            else if (owner == player)
            {
                return $"You already have \n{name} field.";
            }
            else
            {
                player.LessMoney(rental);
                owner.MoreMoney(rental);
                return $"{name} is taken.\nYou have to pay {rental}$ to \nowner of {name} field.";
            }
        }
    }
}

