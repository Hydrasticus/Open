﻿using System.ComponentModel.DataAnnotations;

namespace Open.Facade.Location {

    //TODO: different than Lab17End
    public class WebPageAddressViewModel : AddressViewModel {

        private string url;

        [Required]
        [RegularExpression(@"(http(s)?://)?([\w-]+\.)+[\w-]+(/[\w- ;,./?%&=]*)?")]
        public string Url {
            get => getString(ref url);
            set => url = value;
        }

        public override string ToString() {
            return Url;
        }
    }
}
