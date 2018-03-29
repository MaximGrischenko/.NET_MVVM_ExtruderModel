namespace SharedCommunicationClassesLibrary
{
    public interface IPidActual
    {
        int Loop { get; set; }
        double FromPidTempReference { get; set; }
        double FromPidTempActual { get; set; }
    }
}