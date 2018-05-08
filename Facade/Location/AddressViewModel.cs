using System.ComponentModel;
using Open.Core;
using Open.Facade.Common;

namespace Open.Facade.Location {

    public abstract class AddressViewModel : UniqueEntityViewModel {

        private string addressType;

        [DisplayName("Address type")]
        public string AddressType {
            get => getString(ref addressType, Constants.Unspecified);
            set => addressType = value;
        }
    }
}
