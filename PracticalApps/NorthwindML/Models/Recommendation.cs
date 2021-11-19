// Used as output of the machine learning algorithm

namespace NorthwindML.Models {
    public class Recommendation {
        public uint CoboughtProductID { get; set; }
        public float Score { get; set; } // Score determined by the ML algorithm
    }
}