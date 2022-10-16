using System;
using System.Collections.Generic;

namespace SimpleLocalization {
    [Serializable]
    public class LocalizerData {
        public List<Translation> localizations { get; set; }
    }
}
