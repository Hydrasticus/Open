namespace Open.Data.Location {

    public class GeographicAddressDbRecord : AddressDbRecord {

        private string countryID;
        private CountryDbRecord country;

        public string CountryID {
            get => getString(ref countryID);
            set => countryID = value;
        }

        public virtual CountryDbRecord Country {
            get => getValue(ref country);
            set => country = value;
        }
    }
}
