namespace ResourceManagement.Extensions.Sql.PriceTiers
{
    public class DatabasePriceTierSetting
    {
        /// <summary>
        /// Gets or sets the period in minutes.
        /// </summary>
        public int Period { get; set; }

        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the amount of buffer in assigned DTU level based on recent usage.
        /// </summary>
        public int Buffer { get; set; }
        public string MinTier { get; set; }
        public string MaxTier { get; set; }

        /// <summary>
        /// Gets or sets the change frequency limit. 
        /// The change frequency limit prevents the databas from being
        /// scaled up or down to frequently. If the database was scaled
        /// up or down within this time limit, no further adustments will
        /// be made.
        /// </summary>
        public int MinChangeFrequency { get; set; }

        public DatabasePriceTierSchedule[] Schedules { get; set; }

        public static DatabasePriceTierSetting Defaults()
        {
            DatabasePriceTierSetting setting = new DatabasePriceTierSetting();
            setting.Value = "maximum";
            setting.Period = 60;
            setting.Buffer = 100;
            setting.MinChangeFrequency = 15;
            return setting;
        }
    }
}