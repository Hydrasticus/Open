using Open.Core;

namespace Open.Data.Common {
    
    public abstract class IdentifiedDbRecord : UniqueDbRecord {

        private string code;
        private string name;

        public string Code {
            get => GetValue(ref code, Constants.Unspecified);
            set => code = value;
        }

        public string Name {
            get => GetValue(ref name, Code);
            set => name = value;
        }

        public override string ID {
            get => GetValue(ref id, Name);
            set => id = value;
        }
    }
}
