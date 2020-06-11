using Newtonsoft.Json.Linq;
using smart_booking.BLL.DataTransferModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smart_booking.Utils
{
    public class TZRead
    {
        public string CountryCode { get; set; }
        public string TimeZone { get; set; }
        public string UTC_Jan_1_2020 { get; set; }
        public string DST_Jul_1_2020 { get; set; }

    }

    public class CountryRead
    {
        public string code { get; set; }
        public string name { get; set; }
        public string native { get; set; }
        public string phone { get; set; }
        public string capital { get; set; }
        public string currency { get; set; }
        public string emoji { get; set; }
        public string emojiU { get; set; }
    }

    public class SeedDbUponRequest
    {
        public List<CountryDTM> CountriesListDtm;
        public List<Time_zoneDTM> ZonesListDtm;
        public List<CurrencyDTM> CurrenciesLidtDtm;
        public PageLanguageDTM PageLanguage;
        public ServiceCategoryDTM ServCategory;
        public ServiceDTM Service;
        public SeedDbUponRequest()
        {
            CountriesListDtm = new List<CountryDTM>();
            ZonesListDtm = new List<Time_zoneDTM>();
            CurrenciesLidtDtm = new List<CurrencyDTM>();
            WriteCountryData();
            SeedServiceLanguageDate();
        }
        public void WriteCountryData()
        {
            var myCountries = File.ReadAllText(@"Country.json");
            JObject countries = JObject.Parse(myCountries);
            JArray countriesArray = (JArray)countries["results"];
            IList<CountryRead> countriesList = countriesArray.ToObject<IList<CountryRead>>();
            for (int i = 0; i < countriesList.Count; i++)
            {
                CountryDTM c = new CountryDTM();
                c.Code = countriesList[i].code;
                c.Name = countriesList[i].name;
                c.Native = countriesList[i].native;
                c.PhonePrefix = countriesList[i].phone;
                c.Capital = countriesList[i].capital;
                c.Currency_ = countriesList[i].currency;
                c.Emoji = countriesList[i].emoji;
                c.EmojiU = countriesList[i].emojiU;

                CountriesListDtm.Add(c);
            }

            //Timezone
            var myZones = File.ReadAllText(@"Timezone_Time_Zones_Dataset.json");
            JObject zones = JObject.Parse(myZones);
            JArray zonesArray = (JArray)zones["results"];
            IList<TZRead> zonesList = zonesArray.ToObject<IList<TZRead>>();
            for (int i = 0; i < zonesList.Count; i++)
            {
                Time_zoneDTM t = new Time_zoneDTM();
                t.Zone = zonesList[i].TimeZone;
                t.CountryCode = zonesList[i].CountryCode;
                t.UTC_Jan_1_2020 = zonesList[i].UTC_Jan_1_2020;
                t.DST_Jul_1_2020 = zonesList[i].DST_Jul_1_2020;

                ZonesListDtm.Add(t);
            }

            //Currencies
            List<string> tempList = new List<string>();
            foreach (CountryDTM c in CountriesListDtm)
            {
                if (!tempList.Contains(c.Currency_) && c.Currency_ != "")
                    tempList.Add(c.Currency_);
            }
            foreach (var curLine in tempList)
            {
                CurrencyDTM cur = new CurrencyDTM();
                cur.Name = curLine;
                CurrenciesLidtDtm.Add(cur);
            }

        }

        public void SeedServiceLanguageDate()
        {
            ServCategory = new ServiceCategoryDTM();
            ServCategory.Name = "Testing category 1";
            PageLanguage = new PageLanguageDTM();
            PageLanguage.Name = "EN";

        }
    }
}
