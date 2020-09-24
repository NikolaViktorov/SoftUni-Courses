namespace _06._Birthday_Celebrations
{
    public interface IBirthable
    {
        string Birthdate { get; set; }
        void CheckBirthdate(string year);
    }
}