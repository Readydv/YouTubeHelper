using System;
using System.Net.Http.Headers;
using YoutubeExplode;
using YoutubeExplode.Converter;
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

    class DownloadVideo : Command
    {
        public override async void Run(string videouRL)
        {
            var youtube = new YoutubeClient();
            var outputFilePath = "video.mp4";

            await youtube.Videos.DownloadAsync(videouRL, outputFilePath, builder => builder.SetPreset(ConversionPreset.VeryFast));

            Console.WriteLine($"Видео сохранено и скачено как {outputFilePath}");
        }

        public override void Cancel()
        {
            // Логика отмены если необходимо
        }
    }

    /// <summary>
    /// Клиентский код
    /// </summary>
    
    class Program
    {
        static void Main(string[] args) 
        {
            Console.WriteLine("Введите URL ссылку на YouTube видео");
            var videoUrl = Console.ReadLine();

            Console.WriteLine("Выберите комманду: 1 - Получить описание видео, 2 - Скачать видео");
            var commandChoice = Console.ReadLine();

            var sender = new Sender();
            Command command = commandChoice switch
            {
                "1" => new GetDiscription(),
                "2" => new DownloadVideo(),
                _ => throw new InvalidOperationException("Неверный выбор команды")
            };
            sender.SetCommand(command);
            sender.Run(videoUrl);
        }

    }
}