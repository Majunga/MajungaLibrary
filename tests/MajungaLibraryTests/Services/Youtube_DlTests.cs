// <copyright file="Youtube_DlTests.cs" company="Majunga.co.uk">
// Copyright (c) Majunga.co.uk. All rights reserved.
// </copyright>

[assembly: Xunit.CollectionBehavior(DisableTestParallelization = true)]
namespace MajungaLibraryTests.BusinessLogic.Services
{
    using System;
    using MajungaLibrary.BusinessLogic.Services;
    using Xunit;

    /// <summary>
    /// Youtube-Dl Service Tests
    /// </summary>
    public class Youtube_DlTests
    {
        [Fact]
        public void GetVideoIdFromQueryString_MissingQueryString_ThrowNullArguementException()
        {
            var youtube_dl = new Youtube_Dl("./");

            Assert.Throws<ArgumentNullException>(() => youtube_dl.GetVideoIdFromQueryString(new Uri("https://youtube.com")));
        }

        [Fact]
        public void GetVideoIdFromQueryString_BadVideoUrl_ThrowNullArguementException()
        {
            var youtube_dl = new Youtube_Dl("./");

            Assert.Throws<ArgumentNullException>(() => youtube_dl.GetVideoIdFromQueryString(new Uri("https://www.youtube.com/watch?b=Test&v=RKTXn_c2tyQ")));
        }

        [Fact]
        public void GetVideoIdFromQueryString_GoodUrl_ReturnsIdOfVideo()
        {
            var youtube_dl = new Youtube_Dl("./");
            var id = "RKTXn_c2tyQ";

            var result = youtube_dl.GetVideoIdFromQueryString(new Uri($"https://www.youtube.com/watch?v={id}"));

            Assert.Equal(result, id);
        }

        [Fact]
        public void GetVideoIdFromQueryString_GoodUrlithExtra_ReturnsIdOfVideo()
        {
            var youtube_dl = new Youtube_Dl("./");
            var id = "spr5smxuO5E";

            var result = youtube_dl.GetVideoIdFromQueryString(new Uri($"https://www.youtube.com/watch?v={id}&t=8s"));

            Assert.Equal(result, id);
        }

        [Fact]
        public void DownloadVideo_GoodUrl_ReturnsFileInfoOfDownloadedVideo()
        {
            var youtube_dl = new Youtube_Dl(string.Empty);
            var id = "uq5MtA33OHk";

            var result = youtube_dl.DownloadVideo(new Uri($"https://www.youtube.com/watch?v={id}"), "test").Result;

            if (result.Exists)
            {
                result.Delete();
            }

            Assert.NotNull(result);
        }

        [Fact]
        public void DownloadVideo_GoodUrlWithExtras_ReturnsFileInfoOfDownloadedVideo()
        {
            var youtube_dl = new Youtube_Dl(string.Empty);
            var id = "uq5MtA33OHk";

            var result = youtube_dl.DownloadVideo(new Uri($"https://www.youtube.com/watch?v={id}&t=1407s"), "test").Result;

            if (result.Exists)
            {
                result.Delete();
            }

            Assert.NotNull(result);
        }
    }
}
