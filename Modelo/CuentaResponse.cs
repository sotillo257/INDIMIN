using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class CuentaResponse
    {
        public bool success { get; set; }
        public string client_id { get; set; }
        public int item_id { get; set; }
        public int total { get; set; }
        public BlockchainRelated blockchain_related { get; set; }
        public int claimable_total { get; set; }
        public int last_claimed_item_at { get; set; }
        public Item item { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Signature
    {
        public string signature { get; set; }
        public int amount { get; set; }
        public int timestamp { get; set; }
    }

    public class BlockchainRelated
    {
        public Signature signature { get; set; }
        public int? balance { get; set; }
        public int? checkpoint { get; set; }
        public int? block_number { get; set; }
    }

    public class Item
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string image_url { get; set; }
        public int updated_at { get; set; }
        public int created_at { get; set; }
    }

    public class ItemRank
    {
        public string client_id { get; set; }
        public int win_total { get; set; }
        public int draw_total { get; set; }
        public int lose_total { get; set; }
        public int elo { get; set; }
        public int rank { get; set; }
        public string name { get; set; }
    }

    public class RankResponse
    {
        public bool success { get; set; }
        public List<ItemRank> items { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }
    }

    public class SmoothLovePotion
    {
        public double usd { get; set; }
    }

    public class CoinGeko
    {
        [JsonProperty("smooth-love-potion")]
        public SmoothLovePotion SmoothLovePotion { get; set; }
    }


}
