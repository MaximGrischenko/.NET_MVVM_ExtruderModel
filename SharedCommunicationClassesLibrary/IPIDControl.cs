namespace SharedCommunicationClassesLibrary
{
    public interface IPIDControl
    {
        int Loop { get; set; }

        double K { get; set; }

        double Ti { get; set; }

        double Td { get; set; }

        double StTemp { get; set; }
    }

}