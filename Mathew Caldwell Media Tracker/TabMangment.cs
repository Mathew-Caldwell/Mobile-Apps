using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using SQLite;

namespace Mathew_Caldwell_Media_Tracker
{
    public class TabMangment
    {
        SQLiteAsyncConnection mediaDB;

        static List<Media> masterMediaList = new List<Media>();

        public static List<Media> everythingList = new List<Media>();
        public static List<Media> releasedList = new List<Media>();
        public static List<Media> upcomingList = new List<Media>();
        public static List<Media> finishedList = new List<Media>();

        public void AddMedia(string title, MediaTypes type, DateOnly releaseDate, string author, string streamingService)
        {
            Media newMedia = new Media();
            newMedia.title = title;
            newMedia.type = type;
            newMedia.releaseDate = releaseDate.ToString("yyyy-MM-dd");
            newMedia.author = author;
            newMedia.streamingService = streamingService;
            masterMediaList.Add(newMedia);
            Save();
        }

        public void SortMedia()
        {
            everythingList.Clear();
            releasedList.Clear();
            upcomingList.Clear();
            finishedList.Clear();

            DateOnly todaysDate = DateOnly.FromDateTime(DateTime.Now);

            foreach (Media media in masterMediaList)
            {
                if (media.finished)
                {
                    finishedList.Add(media);
                }
                else
                {
                    everythingList.Add(media);
                    if (DateOnly.ParseExact(media.releaseDate, "yyyy-MM-dd") > todaysDate)
                    {
                        upcomingList.Add(media);
                    }
                    else
                    {
                        releasedList.Add(media);
                    }
                }     
            }
        }

        public void DeleteMedia(int id)
        {
            mediaDB.DeleteAsync(id).Wait();
            Media mediaToRemove = masterMediaList[id - 1]; // -1 because autoincrement isnt zero indexed but lists are
            masterMediaList.Remove(mediaToRemove);
            Save();
        }
       

        #region Managment
        void Save()
        {
            foreach (Media media in masterMediaList)
            {
                mediaDB.InsertAsync(media);
            }
            SortMedia();
        }

        public void load()
        {
            List<Media> loadMediaList = mediaDB.Table<Media>().ToListAsync().Result;
            foreach (Media media in loadMediaList)
            {
                masterMediaList.Add(media);
                
            }

            SortMedia();
        }

        public void InitialiseDatabase()
        {
            var localDataPath = FileSystem.Current.AppDataDirectory;
            var fullFilePath = Path.Combine(localDataPath, "mediaDB.sql");

            Debug.WriteLine(fullFilePath);

            mediaDB = new SQLiteAsyncConnection(fullFilePath);
            mediaDB.CreateTableAsync<Media>().Wait();
        }
        #endregion
    }
}
