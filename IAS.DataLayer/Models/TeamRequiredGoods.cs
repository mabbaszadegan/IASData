namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TeamRequiredGoods
    {
        public int TeamRequiredGoodsId { get; set; }

        public int TeamId { get; set; }

        public int GoodsId { get; set; }

        public double GoodsRecommendedCount { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual Goods Goods { get; set; }

        public virtual Team Team { get; set; }
    }
}
