﻿using System;

namespace TheWanderersOutpost.Api.Models.RpgChar
{
    public class Item
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Desc { get; set; }
        public int Qty { get; set; }
        public double Weight { get; set; }
        public int Cost { get; set; }
        public string CurrencyDenomination { get; set; }
    }
}
