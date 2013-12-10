namespace RaptoRCon.Games.Dice
{
    public class AllPlayerSubset : PlayerSubset
    {
        /// <summary>
        /// Creates a new <see cref="AllPlayerSubset"/> instance
        /// </summary>
        public AllPlayerSubset()
            : base(PlayerSubsetType.All)
        {
        }
    }
}
