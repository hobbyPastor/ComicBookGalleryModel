﻿using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Diagnostics;

namespace ComicBookGalleryModel
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                context.Database.Log = (message) => Debug.WriteLine(message);

                var comicBookId = 1;

                //var comicBook1 = context.ComicBooks.Find(comicBookId);
                //var comicBook2 = context.ComicBooks.Find(comicBookId);

                var comicBook1 = context.ComicBooks
                        .Include(cb => cb.Series)
                        .Include(cb => cb.Artists.Select(a => a.Artist))
                        .Include(cb => cb.Artists.Select(a => a.Role))
                        .SingleOrDefault(cb => cb.Id == comicBookId);

                Debug.WriteLine("Changing Description Property");
                comicBook1.Description = "New Value";
                var comicBook2 = context.ComicBooks
                    .SingleOrDefault(cb => cb.Id == comicBookId); //FirstOrDefault, Single, First


                //var comicBooks = context.ComicBooks.ToList();
                //var comicBooksQuery = from cb in context.ComicBooks select cb;
                //var comicBooks = comicBooksQuery
                //    .Include(cb => cb.Series)
                //    .OrderByDescending(cb => cb.IssueNumber)
                //    .ThenBy(cb => cb.PublishedOn)
                //    .ToList();

                //var comicBooksQuery = context.ComicBooks
                //    .Include(cb => cb.Series)
                //    .OrderByDescending(cb => cb.IssueNumber);

                //var comicBooks = comicBooksQuery.ToList();

                //var comicBooks2 = comicBooksQuery
                //    .Where(cb => cb.AverageRating < 7)
                //    .ToList();

                //foreach (var comicBook in comicBooks)
                //{
                //    Console.WriteLine(comicBook.DisplayText);
                //}
                //Console.WriteLine();
                //Console.WriteLine("# of comic books {0}", comicBooks.Count);
                //Console.WriteLine();

                //foreach (var comicBook in comicBooks2)
                //{
                //    Console.WriteLine(comicBook.DisplayText);
                //}
                //Console.WriteLine();
                //Console.WriteLine("# of comic books {0}", comicBooks2.Count);




                //var comicBooks = context.ComicBooks
                //    //Eager Laoding
                //    //.Include(cb => cb.Series)
                //    //.Include(cb => cb.Artists.Select(a => a.Artist))
                //    //.Include(cb => cb.Artists.Select(a => a.Role))
                //    .ToList();

                //foreach (var comicBook in comicBooks)
                //{
                //    //Explicit Loading
                //    if (comicBook.Series == null)
                //    {
                //        context.Entry(comicBook)
                //            .Reference(cb => cb.Series)
                //            .Load();
                //    }
                //    var artistRoleNames = comicBook.Artists
                //        .Select(a => $"{a.Artist.Name} : {a.Role.Name}").ToList();
                //    var artistsRolesDisplayText = string.Join(", ", artistRoleNames);
                //    Console.WriteLine(comicBook.DisplayText);
                //    Console.WriteLine(artistsRolesDisplayText);
                //}
                Console.ReadLine();
            }
        }
    }
}
