namespace BaseConverter.Extensions
{
    public static class BoolExtension
    {
        public static int ToInt(this bool value) =>
            value ? 1 : 0;
    }
}
