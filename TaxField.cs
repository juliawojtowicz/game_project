namespace C1gameProject
{
    public class TaxField : GameField
    {

        public int taxAmount;

        public TaxField(int _index, string _name, int _taxAmount) : base(_index, _name)
        {
            taxAmount = _taxAmount;
        }

        public override string PlayerAction(Player player)
        {
            player.LessMoney(taxAmount);
            return $"{name}: {taxAmount}";
        }
    }
}