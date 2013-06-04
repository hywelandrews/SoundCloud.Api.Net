namespace SoundCloud.Api.Net.Resources.Filters
{
    public sealed class LicenseFilter
    {
        public static readonly LicenseFilter NoRightsReserved = new LicenseFilter("no-rights-reserved");
        public static readonly LicenseFilter AllRightsReserved = new LicenseFilter("all-rights-reserved");
        public static readonly LicenseFilter CcBy = new LicenseFilter("cc-by");
        public static readonly LicenseFilter CcByNc = new LicenseFilter("cc-by-nc");
        public static readonly LicenseFilter CcByNd = new LicenseFilter("cc-by-nd");
        public static readonly LicenseFilter CcByNcSa = new LicenseFilter("cc-by-nc-sa");
        public static readonly LicenseFilter CcByNcNd = new LicenseFilter("cc-by-nc-nd");

        private LicenseFilter(string value)
        {
            Value = value;
        }

        private string Value { get; set; }

        public static implicit operator string(LicenseFilter op)
        {
            return op.Value;
        }
    }
}
