namespace SoundCloud.Api.Net.Resources.Filters
{
    public sealed class TypeFilter
    {
        public static readonly TypeFilter Original = new TypeFilter("original");
        public static readonly TypeFilter Remix = new TypeFilter("remix");
        public static readonly TypeFilter Live = new TypeFilter("live");
        public static readonly TypeFilter Recording = new TypeFilter("recording");
        public static readonly TypeFilter Spoken = new TypeFilter("spoken");
        public static readonly TypeFilter Podcast = new TypeFilter("podcast");
        public static readonly TypeFilter Demo = new TypeFilter("demo");
        public static readonly TypeFilter InProgress = new TypeFilter("in progress");
        public static readonly TypeFilter Stem = new TypeFilter("stem");
        public static readonly TypeFilter Loop = new TypeFilter("loop");
        public static readonly TypeFilter SoundEffect = new TypeFilter("sound effect");
        public static readonly TypeFilter Sample = new TypeFilter("sample");
        public static readonly TypeFilter Other = new TypeFilter("other");

        private TypeFilter(string value)
        {
            Value = value;
        }

        private string Value { get; set; }

        public static implicit operator string(TypeFilter op)
        {
            return op.Value;
        }
    }
}
