namespace Open.Facade.Location {

    public class WebPageAddressViewModel : AddressViewModel {

        private string url;

        public string Url {
            get => getString(ref url);
            set => url = value;
        }
    }
}
