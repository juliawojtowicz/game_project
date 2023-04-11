namespace C1gameProject
{
    public class OtherField : GameField
    {
        public OtherField(int _index, string _name) : base(_index, _name) { }

        public override string PlayerAction(Player player)
        {
            if (index == 0)
            {
                player.MoreMoney(200);
                return "When you go through the \nSTART field you get 200.";
            }
            else if (index == 5)
            {
                return "You are visiting your \nfriend in Jail.";
            }
            else if (index == 10)
            {
                return "You are on Parking.";
            }
            else
            {
                return "You have to wait \nnext two runds.";
            }

        }
    }
}
