using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivo.Services
{
    public class SettingsService
    {
        private static ISettings AppSettings => CrossSettings.Current;

        /// <summary>
        /// Server Uri
        /// </summary>
        public static string Uri
        {
            get => AppSettings.GetValueOrDefault(nameof(Uri), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(Uri), value);
        }

        /// <summary>
        /// Service API key
        /// </summary>
        public static string ApiKey
        {
            get => AppSettings.GetValueOrDefault(nameof(ApiKey), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(ApiKey), value);
        }

        /// <summary>
        /// Units
        /// </summary>
        public static string Units
        {
            get => AppSettings.GetValueOrDefault(nameof(Units), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(Units), value);
        }
    }
}
