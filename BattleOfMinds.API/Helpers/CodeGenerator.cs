namespace BattleOfMinds.API.Helpers
{
    public static class CodeGenerator
    {
        public static string Generator()
        {
            Random rnd = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, 6).Select(o => o[rnd.Next(o.Length)]).ToArray());
        }
        public static string GeneratorPass()
        {
            Random rnd = new Random();
            const string chars = "ABCDEFGIHJKLMNOPRSTUVYZW0123456789";
            return new string(Enumerable.Repeat(chars, 8).Select(o => o[rnd.Next(o.Length)]).ToArray());
        }
    }
}
