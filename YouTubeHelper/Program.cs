using System;
using YoutubeExplode;
using YoutubeExplode.Search;
using YoutubeExplode.Videos;

namespace YouTubeHelper
{

    /// <summary>
    /// Базовый класс команды
    /// </summary>
    
    abstract class Command
    {
        public abstract void Run(string videoUrl);
        public abstract void Cancel();
    }

    /// <summary>
    /// Конкретная реализация команды для получения описания
    /// </summary>
    class GetDiscription : Command
    {
        public override async void Run(string videoUrl)
        {
            var youtube = new YoutubeClient();
            var video = await youtube.Videos.GetAsync(videoUrl);

            Console.WriteLine($"Название {video.Title}");
            Console.WriteLine($"Описание {video.Description}");
        }

        public override void Cancel()
        {
            // Логика отмены если необходимо
        }

    }

    class Receiver
    {
        public void Operation()
        {
            Console.WriteLine("Процесс запущен");
        }
    }



    /// <summary>
    /// Клиентский код
    /// </summary>
    
    class Program
    {
        static void Main(string[] args) 
        { 

        }

    }
}