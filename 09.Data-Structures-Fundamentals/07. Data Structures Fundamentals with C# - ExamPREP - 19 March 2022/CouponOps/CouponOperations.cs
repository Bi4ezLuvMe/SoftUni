namespace CouponOps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CouponOps.Models;
    using Interfaces;

    public class CouponOperations : ICouponOperations
    {
        Dictionary<string,Coupon>couponsByCode =  new Dictionary<string,Coupon>();
        Dictionary<string,Website>websitesByDomain = new Dictionary<string,Website>();
        public void AddCoupon(Website website, Coupon coupon)
        {
            if (!websitesByDomain.ContainsKey(website.Domain))
            {
                throw new ArgumentException();
            }
            couponsByCode.Add(coupon.Code, coupon);
            website.coupons.Add(coupon);
            coupon.websites.Add(website);
        }

        public bool Exist(Website website)=>websitesByDomain.ContainsKey(website.Domain);

        public bool Exist(Coupon coupon) => couponsByCode.ContainsKey(coupon.Code);

        public IEnumerable<Coupon> GetCouponsForWebsite(Website website) 
        {
            if (!websitesByDomain.ContainsKey(website.Domain))
            {
                throw new ArgumentException();
            }
            if (website.coupons.Count == 0)
            {
                return new List<Coupon>();
            }
            return website.coupons;
        }

        public IEnumerable<Coupon> GetCouponsOrderedByValidityDescAndDiscountPercentageDesc() => couponsByCode.Values.OrderByDescending(x => x.Validity).ThenByDescending(x => x.DiscountPercentage);

        public IEnumerable<Website> GetSites() => websitesByDomain.Values;

        public IEnumerable<Website> GetWebsitesOrderedByUserCountAndCouponsCountDesc() => websitesByDomain.Values.OrderBy(x => x.UsersCount).ThenByDescending(x => x.coupons.Count);

        public void RegisterSite(Website website)
        {
            if (websitesByDomain.ContainsKey(website.Domain))
            {
                throw new ArgumentException();
            }
            websitesByDomain.Add(website.Domain, website);
        }

        public Coupon RemoveCoupon(string code)
        {
            if (!couponsByCode.ContainsKey(code))
            {
                throw new ArgumentException();
            }
            Coupon coupon = couponsByCode[code];
            foreach (var website in coupon.websites)
            {
                website.coupons.Remove(coupon);
            }
            couponsByCode.Remove(code);
            return coupon;
        }

        public Website RemoveWebsite(string domain)
        {
            if (!websitesByDomain.ContainsKey(domain))
            {
                throw new ArgumentException();
            }
            Website website = websitesByDomain[domain];
            foreach (var coupon in website.coupons)
            {
                couponsByCode.Remove(coupon.Code);
            }
            websitesByDomain.Remove(domain);
            return website;
        }

        public void UseCoupon(Website website, Coupon coupon)
        {
            if (!websitesByDomain.ContainsKey(website.Domain) || !couponsByCode.ContainsKey(coupon.Code))
            {
                throw new ArgumentException();
            }
            if (!website.coupons.Contains(coupon))
            {
                throw new ArgumentException();
            }
            website.coupons.Remove(coupon);
            couponsByCode.Remove(coupon.Code);
        }
    }
}
