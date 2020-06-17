namespace app.Models {
    public class CalculateModel {
        public string Value1 { get; set; }
        public string Value2 { get; set; }
    }

    public class CalculateResultModel {
        public bool errorFlg { get; set; }
        public string errorMessage { get; set; }
        public int Result { get; set; }

        public CalculateResultModel() {
            errorFlg = false;
        }
    }
}