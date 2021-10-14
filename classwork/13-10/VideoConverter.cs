using System;
using System.Threading.Tasks;

namespace _13_10
{
    public class VideoConverter
    {
        public delegate void VideoConverted(string messsage);

        public VideoConverter OnVideoConverted;
        async ValueTask Convert(string title)
        {
            await Task.Delay(5000);

            OnVideoConverted.Invoke(title);
        }
    }
}