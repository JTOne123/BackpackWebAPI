﻿namespace BackpackWebAPI.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents the root object for the IGetCurrencies
    /// </summary>
    public class CurrenciesRoot
    {
        /// <summary>
        /// The main response data for this API.
        /// </summary>
        [JsonProperty("response")]
        public CurrenciesResponse Response { get; private set; }
    }

    /// <summary>
    /// Represents the main response data for this API.
    /// </summary>
    public class CurrenciesResponse
    { 
        /// <summary>
        /// Whether or not the query was a success.
        /// </summary>
        [JsonProperty("success")]
        public bool IsSuccess { get; private set; }

        /// <summary>
        /// If <see cref="BackpackWebAPI.Models.CurrenciesResponse.IsSuccess"/> is false, this contains the reason for faliure.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; private set; }

        /// <summary>
        /// A dictionary of currencies with the internal currency name as keys.
        /// </summary>
        [JsonProperty("currencies")]
        public IReadOnlyDictionary<string, Currency> Currencies { get; private set; }

        /// <summary>
        /// Steam game AppID.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>
        /// URL pointing towards backpack.tf.
        /// </summary>
        [Obsolete("This property is not needed or necessary and will be removed in a future version.")]
        [JsonProperty("url")]
        public string Url { get; private set; }
    }

    /// <summary>
    /// Represents an individual currency.
    /// </summary>
    public class Currency
    {
        /// <summary>
        /// The currency's name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>
        /// The currency's in-game quality.
        /// </summary>
        [JsonProperty("quality")]
        public long Quality { get; private set; }

        /// <summary>
        /// The currency's internal priceindex.
        /// </summary>
        [JsonProperty("priceindex")]
        public string PriceIndex { get; private set; }

        /// <summary>
        /// The currency's internal singular name.
        /// </summary>
        [JsonProperty("single")]
        public string SingularName { get; private set; }

        /// <summary>
        /// The currency's internal plural name.
        /// </summary>
        [JsonProperty("plural")]
        public string PluralName { get; private set; }

        /// <summary>
        /// Number of decimal places the currency should be rounded to.
        /// </summary>
        [JsonProperty("round")]
        public long? Round { get; private set; }

        /// <summary>
        /// Unsure what this is used for.
        /// </summary>
        [JsonProperty("blanket")]
        public long? Blanket { get; private set; }

        /// <summary>
        /// The currency's crafability; either "Craftable" or "Non-Craftable".
        /// </summary>
        [JsonProperty("craftable")]
        public string Craftable { get; private set; }

        /// <summary>
        /// The currency's tradability; safe to always assume "Tradable".
        /// </summary>
        [JsonProperty("tradable")]
        public string Tradable { get; private set; }

        /// <summary>
        /// The currency's in-game definition index.
        /// </summary>
        [JsonProperty("defindex")]
        public long DefIndex { get; private set; }

        /// <summary>
        /// The currencie's price.
        /// </summary>
        [JsonProperty("price")]
        public CurrencyPrice Price { get; private set; }
    }

    /// <summary>
    /// Represents the currency's price.
    /// </summary>
    public class CurrencyPrice
    {
        /// <summary>
        /// The value for this currency as a multiple of <see cref="BackpackWebAPI.Models.CurrencyPrice.CurrencyType"/>.
        /// </summary>
        [JsonProperty("value")]
        public double Value { get; private set; }

        /// <summary>
        /// The type of currency used to price this currency.
        /// </summary>
        [JsonProperty("currency")]
        public string CurrencyType { get; private set; }

        /// <summary>
        /// <para>A relative difference between the last price and current price in the lowest currency.</para>
        /// <para>If this currency is the lowest currency, then this is USD.</para>
        /// <para>If this is equal to the value, assume this is a new currency.</para>
        /// <para>If the difference is 0, assume a refresh (no change).</para>
        /// </summary>
        [JsonProperty("difference")]
        public double Difference { get; private set; }

        /// <summary>
        /// The last time this item was updated, in UTC. If it is the UTC Epoch, assume there has been no update.
        /// </summary>
        public DateTime LastUpdate
            => new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(_lastUpdate);

        [JsonProperty("last_update")]
        private long _lastUpdate;

        /// <summary>
        /// The currency's upper price; it's unlikely this will be set for basic currencies like metal or keys.
        /// </summary>
        [JsonProperty("value_high")]
        public double HighValue { get; private set; }
    }
}
