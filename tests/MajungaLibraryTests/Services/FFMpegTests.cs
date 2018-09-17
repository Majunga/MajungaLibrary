// <copyright file="FFMpegTests.cs" company="Majunga.co.uk">
// Copyright (c) Majunga.co.uk. All rights reserved.
// </copyright>

namespace MajungaLibraryTests.BusinessLogic.Services
{
    using System;
    using MajungaLibrary.BusinessLogic.Services;
    using Xunit;

    /// <summary>
    /// FFMpeg service tests
    /// </summary>
    public class FFMpegTests
    {
        [Fact]
        public void ConvertToMp4_GoodUrl_ReturnsFileInfoOfDownloadedVideo()
        {
            var downloadedVideo = new Youtube_Dl(string.Empty).DownloadVideo(new Uri($"https://www.youtube.com/watch?v=uq5MtA33OHk"), "test").Result;

            var times = Tuple.Create<string, string>(null, null);

            var ffmpeg = new FFMpeg(string.Empty).ConvertToMp4(downloadedVideo, times).Result;

            if (downloadedVideo.Exists)
            {
                downloadedVideo.Delete();
            }

            if (ffmpeg.Exists)
            {
                ffmpeg.Delete();
            }

            Assert.NotNull(ffmpeg);
        }

        [Fact]
        public void ConvertToMp4_GoodUrlWithStartTime_ReturnsFileInfoOfDownloadedVideo()
        {
            var downloadedVideo = new Youtube_Dl(string.Empty).DownloadVideo(new Uri($"https://www.youtube.com/watch?v=uq5MtA33OHk"), "test").Result;

            var times = Tuple.Create<string, string>("00:00:05", null);

            var ffmpeg = new FFMpeg(string.Empty).ConvertToMp4(downloadedVideo, times).Result;

            if (downloadedVideo.Exists)
            {
                downloadedVideo.Delete();
            }

            if (ffmpeg.Exists)
            {
                ffmpeg.Delete();
            }

            Assert.NotNull(ffmpeg);
        }
    }
}
