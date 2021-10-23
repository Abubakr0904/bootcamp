namespace abdulrcsApi
{
    public static class Helpers
    {
        public static void ChoosePlace(string city)
        {
            Program.prayerTime = "https://muslimsalat.com/{city}.json?key=api_key";
        }
    }
}
