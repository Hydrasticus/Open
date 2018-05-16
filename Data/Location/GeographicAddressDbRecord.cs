namespace Open.Data.Location {

    //TODO: different than Lab17End
    public class GeographicAddressDbRecord : AddressDbRecord {

        private string countryID;
        private CountryDbRecord country;

        public string CountryID {
            get => getString(ref countryID);
            set => countryID = value;
        }

        public virtual CountryDbRecord Country { get; set; }
    }
}
