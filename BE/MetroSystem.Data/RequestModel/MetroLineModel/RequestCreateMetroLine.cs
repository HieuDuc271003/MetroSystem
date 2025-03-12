namespace MetroSystem.RequestModel.MetroLineModel
{
    public class RequestCreateMetroLine
    {

        public required string LineName { get; set; }

        public required double Distance { get; set; }
    }
}
