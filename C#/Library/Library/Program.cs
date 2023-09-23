#nullable enable
using System;
using System.Collections.Generic;
using System.Threading;
using System.Globalization;
using System.IO;
using System.Text;

namespace Library
{
    internal static class Program
    {
        private static List<Book> _bookList = new();
        private static List<User> _userList = new();
        private const string BooksPath = @"data/books.txt";
        private const string UsersPath = @"data/users.txt";

        private static void Main()
        {
            
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine(strings.LanguageSwitch);
            switch (GetYourChoice())
            {
                case 'h':
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("hu-HU");
                    break;
                case 'e':
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    break;
                default:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("ja-JP");
                    break;
            }
            
            Console.Clear();

            Console.WriteLine(strings.WelcomeText);
            // Thread.Sleep(2000);        
            if (File.Exists(BooksPath)) ReadBooks();
            if (File.Exists(UsersPath)) ReadUsers();
            Console.WriteLine(strings.BookNumberText, _bookList.Count);
            Console.WriteLine(strings.UserNumberText, _userList.Count);

            // Start of the program
            while (true)
            {
                Console.Write(strings.InfoCommandsText);
                Console.WriteLine();
                switch (GetYourChoice())
                {
                    //Adding something
                    case 'a':
                        Console.Clear();
                        Console.Write(strings.WhatToAdd);
                        Console.Write(strings.InfoCommandsAddText);
                        Console.WriteLine();
                        switch (GetYourChoice())
                        {
                            //Adding a user
                            case 'u':
                                RecordAUser();
                                break;

                            //Adding a book
                            case 'b':
                                RecordABook();
                                break;

                            // If escape pressed
                            case 27:
                                Thread.Sleep(500);
                                Console.Clear();
                                break;
                        }

                        break;

                    // Modify something
                    case 'm':
                        Console.WriteLine(strings.InfoUnderDevelopement);
                        Thread.Sleep(1500);
                        break;

                    // Read from files
                    case 'r':
                        Console.WriteLine();
                        Console.Clear();

                        //Print out the instructions
                        Console.Write(strings.WhatToRead);
                        Console.Write(strings.InfoCommandsAddText);
                        switch (GetYourChoice())
                        {
                            // Read the Users file
                            case 'u':
                                Console.Clear();
                                ReadUsers();
                                foreach (var t in _userList)
                                {
                                    t.Print();
                                    Console.WriteLine();
                                }
                                Thread.Sleep(1500);
                                break;

                            // Read the books file
                            case 'b':
                                Console.Clear();
                                ReadBooks();
                                foreach (var t in _bookList)
                                {
                                    t.Print();
                                    Console.WriteLine();
                                }

                                break;

                            // Escape pressed
                            case 27:
                                Console.Clear();
                                break;
                        }

                        break;

                    // Quit
                    case 'q':
                        Environment.Exit(0);
                        break;

                    //Book management
                    case 'b':
                        Console.Clear();
                        Console.WriteLine(strings.InfoWantToReturnOrBorrow);
                        Console.Write(strings.YourChoice);
                        switch (GetYourChoice())
                        {
                            case 'b':
                                Console.WriteLine(strings.InfoUnderDevelopement);
                                Thread.Sleep(1500);
                                break;
                            case 'r':
                                Console.WriteLine(strings.InfoUnderDevelopement);
                                Thread.Sleep(1500);
                                break;
                        }

                        break;
                    //escape pressed
                    case 27:
                        Thread.Sleep(1000);
                        Console.Clear();

                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine(strings.InfoWrongInput);
                        break;
                }
            }

            // ReSharper disable once FunctionNeverReturns
        }

        //Choice for options
        private static int GetYourChoice()
        {
            int yourChice = Console.ReadKey(true).KeyChar;
            return yourChice;
        }

        //Choice for ID
        //TODO uncomment when using it
        /*private static int ChooseId()
        {
            var temp = 0;
            string? yourChice;
            do
            {
                yourChice = Console.ReadLine();
                if (!int.TryParse(yourChice, out _))
                    Console.Write(strings.InfoWrongInputValue);
                else
                    temp = int.Parse(yourChice);
            } while (!int.TryParse(yourChice, out _));

            return temp;
        }*/


        /*!! Book management HERE !!*/
        //Recording a book
        private static void RecordABook()
        {
            if (File.Exists(BooksPath))
            {
                using var readText = new StreamReader(BooksPath);
                while (!readText.EndOfStream)
                {
                    _bookList = new List<Book>();
                    var line = readText.ReadLine();
                    if (line == null) continue;
                    var values = line.Split(';');
                    var tempBookr = new Book(int.Parse(values[0]), values[1], values[2]);
                    _bookList.Add(tempBookr);
                }
            }
            else
                File.Create(BooksPath).Close();


            var tempBook = _bookList.Count == 0
                ? new Book(0, null, null)
                : new Book(_bookList[^1].BookId, null, null);

            Console.WriteLine();
            Console.Write(strings.BookTitle);
            tempBook.BookTitle = Console.ReadLine();
            Console.Write(strings.BookAuthor);
            tempBook.BookWriter = Console.ReadLine();
            _bookList.Add(tempBook);


            TextWriter tw = new StreamWriter(BooksPath, true);
            tw.WriteLine(tempBook.BookId + ";" + tempBook.BookTitle + ";" + tempBook.BookWriter + ";" +
                         tempBook.IsBorrowed + ";" + tempBook.IsReturned + ";");
            tw.Close();
            Console.Clear();
            Console.WriteLine(strings.InfoAdded);
        }

        //Reading out books from file
        private static void ReadBooks()
        {
            if (!File.Exists(BooksPath)) return;
            
            _bookList = new List<Book>();
            using var readText =
                new StreamReader(BooksPath);
            while (!readText.EndOfStream)
            {
                var line = readText.ReadLine();
                if (line == null) continue;
                var values = line.Split(';');
                if (!int.TryParse(values[0], out _)) continue;
                var tempBook = new Book(int.Parse(values[0]), values[1], values[2]);
                _bookList.Add(tempBook);
            }
        }


        /*!! User management HERE !!*/
        // Recording a user
        private static void RecordAUser()
        {
            if (File.Exists(UsersPath))
            {
                using var readText = new StreamReader(UsersPath);
                while (!readText.EndOfStream)
                {
                    _bookList = new List<Book>();
                    var line = readText.ReadLine();
                    if (line == null) continue;
                    var values = line.Split(';');
                    var tempUserRead = new User(int.Parse(values[0]), int.Parse(values[1]), values[2], values[3]);
                    _userList.Add(tempUserRead);
                }
            }
            else
                File.Create(UsersPath).Close();


            var tempUser = _userList.Count == 0
                ? new User(0, 0, null, null)
                : new User(_userList[^1].UserId + 1, 0, null, null);

            Console.Write(strings.UserName);
            tempUser.UserName = Console.ReadLine();
            Console.Write(strings.UserAge);
            tempUser.UserAge = int.Parse(Console.ReadLine() ?? string.Empty);
            Console.Write(strings.UserEmail);
            tempUser.UserEmail = Console.ReadLine();
            _userList.Add(tempUser);


            TextWriter tw = new StreamWriter(UsersPath, true);
            tw.WriteLine(tempUser.UserId + ";" + tempUser.UserAge + ";" + tempUser.UserName + ";" +
                         tempUser.UserEmail + ";" + tempUser.IsPremium + ";");
            tw.Close();
            Console.Clear();
            Console.WriteLine(strings.InfoAdded);
        }

        //Reading out users from a file
        private static void ReadUsers()
        {
            if (!IsFileExists(UsersPath)) return;
            _userList = new List<User>();
            using var readText = new StreamReader(UsersPath);
            while (!readText.EndOfStream)
            {
                var line = readText.ReadLine();
                if (line == null) continue;
                var values = line.Split(';');
                var tempUser = new User(int.Parse(values[0]), int.Parse(values[1]), values[2], values[3]);
                _userList.Add(tempUser);
            }
        }
        //Todo Uncomment after finishing it
        
        /*private static void ModifyUserData(string userToSearchFor, int bookBorrowed)
        {
            if(!IsFileExists(UsersPath)) return;
            
            int lines = 0;
            bool userSet = false;
            User tempUser = new User(0, 0, null, null);
                using var readText = new StreamReader(UsersPath);
                while (!readText.EndOfStream)
                {
                    var line = readText.ReadLine();
                    if (line == null) continue;
                    var values = line.Split(';');
                    if (values[0] == userToSearchFor && !userSet)
                    {
                        tempUser = new User(int.Parse(values[0]), int.Parse(values[1]), values[2], values[3]);
                        tempUser.IsPremium = Boolean.Parse(values[4]);
                        tempUser.BorrowedBooks.Add(bookBorrowed);
                        userSet = true;
                    }
                    if(!userSet)
                        lines++;
                }
                readText.Close();

                string borrowedBooks = "";
                foreach (var t in tempUser.BorrowedBooks)
                {
                    if(t == tempUser.BorrowedBooks.Count - 1)
                        borrowedBooks += tempUser.BorrowedBooks[t].ToString();
                    else
                        borrowedBooks += tempUser.BorrowedBooks[t] + ",";
                    
                }
                string writeData = tempUser.UserId + ";" +
                                   tempUser.UserAge + ";" +
                                   tempUser.UserName + ";" +
                                   tempUser.UserEmail + ";" + 
                                   tempUser.IsPremium + ";" + borrowedBooks;
                
                Thread.Sleep(1500);
                LineChanger(writeData, UsersPath, lines+1);
                
        }*/
        
        //TODO uncomment when finishing it
        /*static void LineChanger(string newText, string fileName, int lineToEdit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[lineToEdit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }*/
        
        /*!! Book borrowing management HERE !!*/
        
        //Todo uncomment after finishing it
        //getting the borrowed books from the user
        /*private static void GetBorrowedBooks(int fromUser)
        {
            using var readText =
                new StreamReader(BooksPath);
            while (!readText.EndOfStream)
            {
                var line = readText.ReadLine();
                if (line == null) continue;
                var values = line.Split(';');
                var tempBook = new Book(int.Parse(values[0]), values[1], values[2]);
                if (fromUser == tempBook.BookId)
                {
                    tempBook.Print();
                }
            }
        }*/

        //Todo uncomment after finishing it
        //Borrow out a book
        /*private static void BorrowBook()
        {
            if(!IsFileExists(UsersPath)) return; 
            if(!IsFileExists(BooksPath)) return; 
            
            ReadUsers();
            foreach (var t in _userList)
            {
                t.Print();
            }

            Console.Write(strings.WhoIsBorrowing);
            var userId = ChooseId();
            ReadBooks();
            foreach (var t in _bookList)
            {
                t.Print();
            }
            
            Console.WriteLine(strings.BookToBorrow);
            var bookId = ChooseId();
            
            ModifyUserData(userId.ToString(), bookId);

            // var user = new User(0, 0, null, null);
            // user.BorrowedBooks.Add(0);
        }*/

        
        //TODO uncomment after finishing it
        
        //Return a book
        /*private static void ReturnBook()
        {
            var user = new User(0, 0, null, null);
            user.BorrowedBooks.Add(0);
        }*/

        private static bool IsFileExists(string path)
        {
            if (File.Exists(path)) return true;
            
            Console.WriteLine(strings.ErrorUserFileNotFound);
            Thread.Sleep(2000);
            return false;
        }
    }
}