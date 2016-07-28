namespace Assets.Scripts.Extensions.StaticClasses
{
    public static class IdGenerator
    {
        private static int _id;

        public static int GetId()
        {
            return ++_id;
        }
    }
}