using System.Collections.Generic;

namespace CouponOps.Models
{
    public class Coupon
    {
        public Coupon(string code, int discountPercentage, int validity)
        {
            this.Code = code;
            this.DiscountPercentage = discountPercentage;
            this.Validity = validity;
            this.websites = new List<Website>();
        }

        public string Code { get; set; }
        public int DiscountPercentage { get; set; }
        public int Validity { get; set; }
        public List<Website> websites { get; set; }
    }
}
